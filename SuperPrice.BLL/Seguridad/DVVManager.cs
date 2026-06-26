using System.Data.SqlClient;
using System.Text;
using SuperPrice.BE.Seguridad;
using SuperPrice.DAL;

namespace SuperPrice.BLL.Seguridad
{
    public class DVVManager
    {
        public void ActualizarDVVBitacora()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT DVH FROM Bitacora WHERE DVH IS NOT NULL ORDER BY IdBitacora",
                        cn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                StringBuilder sb =
                    new StringBuilder();

                while (reader.Read())
                {
                    sb.Append(reader["DVH"].ToString());
                }

                reader.Close();

                string dvv =
                    DigitoVerificador.CalcularDVH(sb.ToString());

                SqlCommand actualizar =
                    new SqlCommand(
                        @"IF EXISTS(SELECT * FROM DVV WHERE Tabla='Bitacora')
                          UPDATE DVV
                          SET DigitoVerificador=@DVV
                          WHERE Tabla='Bitacora'
                          ELSE
                          INSERT INTO DVV
                          VALUES('Bitacora',@DVV)",
                        cn);

                actualizar.Parameters.AddWithValue(
                    "@DVV",
                    dvv);

                actualizar.ExecuteNonQuery();
            }
        }
    }
}