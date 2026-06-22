using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperPrice.Forms;
using SuperPrice.DAL;

namespace SuperPrice.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            { }
        }

       
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();

            bool acceso =
                usuarioDAL.ValidarUsuario(
                    txtUsuario.Text,
                    txtPassword.Text);

            if (acceso)
            {
                FrmPrincipal principal = new FrmPrincipal();

                principal.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos");
            }
        }
        

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
