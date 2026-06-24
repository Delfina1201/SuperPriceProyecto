using SuperPrice.BE.Seguridad;
using SuperPrice.BLL.Patrones;
using SuperPrice.BLL.Seguridad;
using SuperPrice.DAL.Seguridad;
using System;
using System.Data;
using System.Windows.Forms;


namespace SuperPrice.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Usuario logueado: " +
                Sesion.ObtenerInstancia()
                      .UsuarioLogueado
                      .NombreUsuario);

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

        private void cerrarSesiónToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            Sesion.ObtenerInstancia().Logout();

            FrmLogin login = new FrmLogin();

            login.Show();

            this.Close();
        }

        private void salirToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }
    }
}