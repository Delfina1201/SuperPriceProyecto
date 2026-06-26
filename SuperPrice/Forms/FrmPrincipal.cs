using SuperPrice.BE.Seguridad;
using SuperPrice.BLL.Patrones;
using SuperPrice.BLL.Seguridad;
using SuperPrice.DAL.Seguridad;
using System;
using System.Data;
using System.Windows.Forms;
using SuperPrice.BLL.Idiomas;

namespace SuperPrice.Forms
{
    public partial class FrmPrincipal : Form, IObserver
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            Traductor.ObtenerInstancia().Suscribir(this);

            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            if (Traductor.ObtenerInstancia().IdiomaActual.Nombre == "Español")
            {
                archivoToolStripMenuItem.Text = "Archivo";
                gestiónToolStripMenuItem.Text = "Gestión";
                ventasToolStripMenuItem.Text = "Ventas";
                seguridadToolStripMenuItem.Text = "Seguridad";
                idiomaToolStripMenuItem.Text = "Idioma";
                españolToolStripMenuItem.Text = "Español";
                englishToolStripMenuItem.Text = "English";
            }
            else
            {
                archivoToolStripMenuItem.Text = "File";
                gestiónToolStripMenuItem.Text = "Management";
                ventasToolStripMenuItem.Text = "Sales";
                seguridadToolStripMenuItem.Text = "Security";
                idiomaToolStripMenuItem.Text = "Language";
                españolToolStripMenuItem.Text = "Spanish";
                englishToolStripMenuItem.Text = "English";
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Usuario: " +
                Sesion.ObtenerInstancia()
                    .UsuarioLogueado
                    .NombreUsuario
             +
                "\nPerfil: " +
                Sesion.ObtenerInstancia()
                    .UsuarioLogueado
                    .Perfil
                    .Nombre
             +
                "\nPermisos: " +
                Sesion.ObtenerInstancia()
                    .UsuarioLogueado
                    .Perfil
                    .Permisos
                    .Count);

            PermisoDAL dal = new PermisoDAL();

            dal.ProbarConexion();

            DataTable tabla = dal.ObtenerTablaPermisos();

            MessageBox.Show(
                "Cantidad de permisos: " +
                tabla.Rows.Count);

            MessageBox.Show("Conexión exitosa");

            PermisoBLL permisoBLL = new PermisoBLL();

            var permisos = permisoBLL.ObtenerPermisos();

            treeView1.Nodes.Clear();

            TreeNode raiz = new TreeNode("Permisos");

            treeView1.Nodes.Add(raiz);

            foreach (Permiso permiso in permisos)
            {
                CargarNodo(raiz, permiso);
            }

            treeView1.ExpandAll();
        }

        private void CargarNodo(TreeNode nodoPadre, Permiso permiso)
        {
            TreeNode nodo = new TreeNode(
                permiso.Codigo + " - " + permiso.Nombre);

            nodoPadre.Nodes.Add(nodo);

            if (permiso is PermisoCompuesto compuesto)
            {
                foreach (Permiso hijo in compuesto.Hijos)
                {
                    CargarNodo(nodo, hijo);
                }
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BitacoraBLL bitacoraBLL =
                new BitacoraBLL();

            Bitacora bitacora =
                new Bitacora();

            bitacora.FechaHora =
                DateTime.Now;

            bitacora.Usuario =
                Sesion.ObtenerInstancia()
                      .UsuarioLogueado
                      .NombreUsuario;

            bitacora.Evento =
                "Logout";

            bitacora.Descripcion =
                "Cierre de sesión.";

            bitacoraBLL.Registrar(
                bitacora);

            Sesion.ObtenerInstancia().Logout();

            FrmLogin login =
                new FrmLogin();

            login.Show();

            this.Close();
        }

        private void salirToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitacora frm =
                new FrmBitacora();

            frm.ShowDialog();
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Traductor.ObtenerInstancia().CambiarIdioma(
                new Idioma
                {
                    Id = 1,
                    Nombre = "Español"
                });
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Traductor.ObtenerInstancia().CambiarIdioma(
                new Idioma
                {
                    Id = 2,
                    Nombre = "English"
                });
        }
    }
}