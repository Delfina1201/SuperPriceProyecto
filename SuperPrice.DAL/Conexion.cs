using System.Data.SqlClient;


namespace SuperPrice.DAL
{
    public class Conexion
    {
        private string cadenaConexion =
            @"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=SuperPrice;
              Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}