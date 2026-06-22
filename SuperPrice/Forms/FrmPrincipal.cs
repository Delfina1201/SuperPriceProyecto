using SuperPrice.BE.Seguridad;
using SuperPrice.BLL.Patrones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            PermisoSimple crearProducto = new PermisoSimple();
            crearProducto.Codigo = "PP001";
            crearProducto.Nombre = "Crear Producto";

            PermisoSimple modificarProducto = new PermisoSimple();
            modificarProducto.Codigo = "PP002";
            modificarProducto.Nombre = "Modificar Producto";

            PermisoCompuesto gestionProductos = new PermisoCompuesto();
            gestionProductos.Codigo = "GE051";
            gestionProductos.Nombre = "Gestión Productos";

            gestionProductos.Agregar(crearProducto);
            gestionProductos.Agregar(modificarProducto);

            MessageBox.Show(
                gestionProductos.Nombre +
                "\nCantidad de permisos: " +
                gestionProductos.Hijos.Count);

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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
