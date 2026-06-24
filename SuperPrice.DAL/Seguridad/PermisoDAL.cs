using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPrice.BE.Seguridad;
using System.Data;
using System.Data.SqlClient;


namespace SuperPrice.DAL.Seguridad
{
    public class PermisoDAL
    {
        public List<Permiso> ObtenerPermisos()
        {
            List<Permiso> permisos =
                new List<Permiso>();

            Dictionary<int, Permiso> diccionario =
                new Dictionary<int, Permiso>();

            Conexion conexion = new Conexion();

            using (SqlConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                    "SELECT * FROM Permisos";

                SqlCommand cmd =
                    new SqlCommand(consulta, cn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    bool esCompuesto =
                        Convert.ToBoolean(
                            reader["EsCompuesto"]);

                    Permiso permiso;

                    if (esCompuesto)
                    {
                        permiso =
                            new PermisoCompuesto();
                    }
                    else
                    {
                        permiso =
                            new PermisoSimple();
                    }

                    permiso.Id =
                        Convert.ToInt32(
                            reader["IdPermiso"]);

                    permiso.Codigo =
                        reader["Codigo"].ToString();

                    permiso.Nombre =
                        reader["Nombre"].ToString();

                    permisos.Add(permiso);

                    diccionario.Add(
                        permiso.Id,
                        permiso);
                }

                reader.Close();

                string consultaRelaciones =
                    "SELECT * FROM PermisoPermiso";

                SqlCommand cmdRelaciones =
                    new SqlCommand(
                        consultaRelaciones,
                        cn);

                SqlDataReader readerRelaciones =
                    cmdRelaciones.ExecuteReader();

                while (readerRelaciones.Read())
                {
                    int idPadre =
                        Convert.ToInt32(
                            readerRelaciones["IdPadre"]);

                    int idHijo =
                        Convert.ToInt32(
                            readerRelaciones["IdHijo"]);

                    PermisoCompuesto padre =
                        diccionario[idPadre]
                        as PermisoCompuesto;

                    Permiso hijo =
                        diccionario[idHijo];

                    if (padre != null)
                    {
                        padre.Agregar(hijo);
                    }
                }

                readerRelaciones.Close();
            }

            List<Permiso> permisosRaiz =
                new List<Permiso>();

            foreach (Permiso permiso in permisos)
            {
                bool esHijo = false;

                foreach (Permiso otro in permisos)
                {
                    if (otro is PermisoCompuesto compuesto)
                    {
                        if (compuesto.Hijos.Contains(permiso))
                        {
                            esHijo = true;
                            break;
                        }
                    }
                }

                if (!esHijo)
                {
                    permisosRaiz.Add(permiso);
                }
            }

            return permisosRaiz;
        }

        public void ProbarConexion()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();
            }
        }

        public DataTable ObtenerTablaPermisos()
        {
            Conexion conexion = new Conexion();

            DataTable tabla = new DataTable();

            using (SqlConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();

                string consulta =
                    "SELECT * FROM Permisos";

                SqlDataAdapter da =
                    new SqlDataAdapter(consulta, cn);

                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
