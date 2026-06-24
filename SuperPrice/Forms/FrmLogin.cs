using SuperPrice.BE;
using SuperPrice.BE.Entidades;
using SuperPrice.DAL;
using SuperPrice.Forms;
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
using SuperPrice.BLL.Seguridad;

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
           
            UsuarioBLL usuarioBLL =
                new UsuarioBLL();

            Usuario usuario =
                usuarioBLL.Login(
                    txtUsuario.Text,
                    txtPassword.Text);

            if (usuario != null)
            {
                Sesion.ObtenerInstancia()
                      .Login(usuario);

                FrmPrincipal principal =
                    new FrmPrincipal();

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
