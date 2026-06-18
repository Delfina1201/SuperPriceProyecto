using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuperPrice.BE.Entidades;

namespace SuperPrice.BLL.Patrones
{
    public sealed class Sesion
    {
        private static Sesion instancia;

        private Sesion()
        {
        }

        public Usuario UsuarioLogueado { get; private set; }

        public static Sesion ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sesion();
            }

            return instancia;
        }

        public void Login(Usuario usuario)
        {
            UsuarioLogueado = usuario;
        }

        public void Logout()
        {
            UsuarioLogueado = null;
        }
    }
}
