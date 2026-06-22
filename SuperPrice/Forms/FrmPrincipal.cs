using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperPrice.BLL.Patrones;


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
