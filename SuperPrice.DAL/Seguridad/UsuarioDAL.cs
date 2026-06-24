using SuperPrice.BE.Entidades;
using SuperPrice.BE.Seguridad;
using System;
using System.Data.SqlClient;

namespace SuperPrice.DAL.Seguridad
{
    public class UsuarioDAL
    {
        public Usuario ObtenerUsuario(
            string nombreUsuario,
            string password)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                    @"SELECT *
                      FROM Usuarios
                      WHERE NombreUsuario = @usuario
                      AND Password = @password
                      AND Activo = 1";

                SqlCommand cmd =
                    new SqlCommand(
                        consulta,
                        cn);

                cmd.Parameters.AddWithValue(
                    "@usuario",
                    nombreUsuario);

                cmd.Parameters.AddWithValue(
                    "@password",
                    password);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario =
                        new Usuario();

                    usuario.IdUsuario =
                        (int)reader["IdUsuario"];

                    usuario.NombreUsuario =
                        reader["NombreUsuario"]
                        .ToString();

                    usuario.Password =
                        reader["Password"]
                        .ToString();

                    usuario.Activo =
                        (bool)reader["Activo"];

                    Perfil perfil = new Perfil();

                    perfil.Id =
                        Convert.ToInt32(
                            reader["IdPerfil"]);

                    perfil.Nombre =
                        "Administrador";

                    usuario.Perfil = perfil;

                    return usuario;
                }
            }

            return null;
        }
    }
}
