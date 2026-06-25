using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPrice.BE.Seguridad;
using System.Data.SqlClient;

namespace SuperPrice.DAL.Seguridad
{
    public class BitacoraDAL
    {
        public void Registrar(Bitacora bitacora)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                    @"INSERT INTO Bitacora
                      (FechaHora,
                       Usuario,
                       Evento,
                       Descripcion)
                      VALUES
                      (@FechaHora,
                       @Usuario,
                       @Evento,
                       @Descripcion)";

                SqlCommand cmd =
                    new SqlCommand(
                        consulta,
                        cn);

                cmd.Parameters.AddWithValue(
                    "@FechaHora",
                    bitacora.FechaHora);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    bitacora.Usuario);

                cmd.Parameters.AddWithValue(
                    "@Evento",
                    bitacora.Evento);

                cmd.Parameters.AddWithValue(
                    "@Descripcion",
                    bitacora.Descripcion);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
