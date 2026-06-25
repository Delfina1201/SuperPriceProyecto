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

            string passwordEncriptada =
                Encriptador.CalcularHash(password);

            return usuarioDAL.ObtenerUsuario(
                nombreUsuario,
                passwordEncriptada);
        }
    }
}