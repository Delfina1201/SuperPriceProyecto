using System;
using System.Data.SqlClient;
using System.Text;
using SuperPrice.DAL;
using SuperPrice.BE.Seguridad;

namespace SuperPrice.BLL.Seguridad
{
    public class VerificadorIntegridad
    {
        public bool Verificar()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                StringBuilder sb = new StringBuilder();

                string consulta = @"SELECT FechaHora,
                                           Usuario,
                                           Evento,
                                           Descripcion,
                                           DVH
                                    FROM Bitacora
                                    ORDER BY IdBitacora";

                SqlCommand cmd = new SqlCommand(consulta, cn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["DVH"] == DBNull.Value)
                        continue;

                    string datos =
                        Convert.ToDateTime(reader["FechaHora"]).ToString("yyyyMMddHHmmss") +
                        reader["Usuario"].ToString() +
                        reader["Evento"].ToString() +
                        reader["Descripcion"].ToString();

                    string dvhCalculado =
                        DigitoVerificador.CalcularDVH(datos);

                    string dvhGuardado =
                        reader["DVH"].ToString();

                    // Verifica el DVH
                    if (dvhCalculado != dvhGuardado)
                        return false;

                    // Lo agrega para calcular el DVV
                    sb.Append(dvhGuardado);
                }

                reader.Close();

                // Calcula el DVV
                string dvvCalculado =
                    DigitoVerificador.CalcularDVH(sb.ToString());

                SqlCommand cmdDVV = new SqlCommand(
                    "SELECT DigitoVerificador FROM DVV WHERE Tabla='Bitacora'",
                    cn);

                object resultado = cmdDVV.ExecuteScalar();

                if (resultado == null)
                    return false;

                string dvvGuardado = resultado.ToString();

                // Verifica el DVV
                if (dvvCalculado != dvvGuardado)
                    return false;
            }

            return true;
        }
    }
}