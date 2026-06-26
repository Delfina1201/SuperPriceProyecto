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

                string datos =
                    bitacora.FechaHora.ToString("yyyyMMddHHmmss") +
                    bitacora.Usuario +
                    bitacora.Evento +
                    bitacora.Descripcion;

                string dvh =
                    DigitoVerificador.CalcularDVH(datos);

                string consulta =
                    @"INSERT INTO Bitacora
              (FechaHora,
               Usuario,
               Evento,
               Descripcion,
               DVH)
              VALUES
              (@FechaHora,
               @Usuario,
               @Evento,
               @Descripcion,
               @DVH)";

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

                cmd.Parameters.AddWithValue(
                    "@DVH",
                    dvh);

                cmd.ExecuteNonQuery();

            }
        }

        public DataTable ObtenerBitacora(string usuario, string evento, DateTime desde, DateTime hasta)
        {
            Conexion conexion = new Conexion();

            DataTable tabla = new DataTable();

            using (SqlConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                    @"SELECT *
                    FROM Bitacora
                    WHERE Usuario LIKE @Usuario
                    AND Evento LIKE @Evento
                    AND FechaHora BETWEEN @Desde AND @Hasta
                    ORDER BY FechaHora DESC";

                SqlCommand cmd =
                    new SqlCommand(
                        consulta,
                        cn);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    "%" + usuario + "%");

                cmd.Parameters.AddWithValue(
                    "@Evento",
                    "%" + evento + "%");

                cmd.Parameters.AddWithValue(
                    "@Desde",
                    desde);

                cmd.Parameters.AddWithValue(
                    "@Hasta",
                    hasta);


                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                da.Fill(tabla);
            }

            return tabla;
        }
    
    }
}
