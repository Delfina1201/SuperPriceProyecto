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
using SuperPrice.BE.Seguridad;
using SuperPrice.BLL.Idiomas;

namespace SuperPrice.Forms
{
    public partial class FrmLogin : Form, IObserver
    {
        public FrmLogin()
        {
            InitializeComponent();

            Traductor.ObtenerInstancia().Suscribir(this);

            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            if (Traductor.ObtenerInstancia().IdiomaActual.Nombre == "Español")
            {
                btnIngresar.Text = "Ingresar";
                this.Text = "Iniciar sesión";
            }
            else
            {
                btnIngresar.Text = "Login";
                this.Text = "Log In";
            }
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL =
                new UsuarioBLL();

            Usuario usuario =
                usuarioBLL.Login(
                    txtUsuario.Text,
                    txtPassword.Text);

            BitacoraBLL bitacoraBLL =
                new BitacoraBLL();

            if (usuario != null)
            {
                Sesion.ObtenerInstancia()
                      .Login(usuario);

                Bitacora bitacora =
                    new Bitacora();

                bitacora.FechaHora =
                    DateTime.Now;

                bitacora.Usuario =
                    usuario.NombreUsuario;

                bitacora.Evento =
                    "Login";

                bitacora.Descripcion =
                    "Inicio de sesión exitoso.";

                bitacoraBLL.Registrar(
                    bitacora);

                FrmPrincipal principal =
                    new FrmPrincipal();

                principal.Show();

                this.Hide();
            }
            else
            {
                Bitacora bitacora =
                    new Bitacora();

                bitacora.FechaHora =
                    DateTime.Now;

                bitacora.Usuario =
                    txtUsuario.Text;

                bitacora.Evento =
                    "Login Fallido";

                bitacora.Descripcion =
                    "Usuario o contraseña incorrectos.";

                bitacoraBLL.Registrar(
                    bitacora);

                MessageBox.Show(
                    "Usuario o contraseña incorrectos");
            }
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
