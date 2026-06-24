using SuperPrice.BE.Entidades;
using SuperPrice.DAL.Seguridad;

namespace SuperPrice.BLL.Seguridad
{
    public class UsuarioBLL
    {
        public Usuario Login(
            string nombreUsuario,
            string password)
        {
            UsuarioDAL usuarioDAL =
                new UsuarioDAL();

            return usuarioDAL.ObtenerUsuario(
                nombreUsuario,
                password);
        }
    }
}