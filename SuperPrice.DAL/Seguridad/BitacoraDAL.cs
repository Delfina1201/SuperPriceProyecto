using SuperPrice.BE.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataTable ObtenerBitacora()
        {
            Conexion conexion = new Conexion();

            DataTable tabla = new DataTable();

            using (SqlConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                    @"SELECT
                FechaHora,
                Usuario,
                Evento,
                Descripcion
              FROM Bitacora
              ORDER BY FechaHora DESC";

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        consulta,
                        cn);

                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
