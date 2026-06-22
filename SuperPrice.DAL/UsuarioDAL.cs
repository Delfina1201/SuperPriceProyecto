using SuperPrice.BE;
using SuperPrice.BE.Entidades;
using System;
using System.Data.SqlClient;

namespace SuperPrice.DAL
{
    public class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        public Usuario Login(string usuario, string password)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                @"SELECT *
                  FROM Usuarios
                  WHERE NombreUsuario = @usuario
                  AND Password = @password
                  AND Activo = 1";

                SqlCommand cmd =
                    new SqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Usuario u = new Usuario();

                    u.IdUsuario =
                        Convert.ToInt32(reader["IdUsuario"]);

                    u.NombreUsuario =
                        reader["NombreUsuario"].ToString();

                    u.Password =
                        reader["Password"].ToString();

                    u.Activo =
                        Convert.ToBoolean(reader["Activo"]);

                    return u;
                }

                return null;
            }
        }
    }
}
