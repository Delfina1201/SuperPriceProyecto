using System.Data.SqlClient;

namespace SuperPrice.DAL
{
    public class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        public bool ValidarUsuario(string usuario, string password)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                    @"SELECT COUNT(*)
                      FROM Usuarios
                      WHERE NombreUsuario = @usuario
                      AND Password = @password
                      AND Activo = 1";

                SqlCommand cmd =
                    new SqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@password", password);

                int cantidad =
                    (int)cmd.ExecuteScalar();

                return cantidad > 0;
            }
        }
    }
}