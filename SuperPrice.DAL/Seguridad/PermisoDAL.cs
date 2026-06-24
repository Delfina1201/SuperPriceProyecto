using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPrice.BE.Seguridad;


namespace SuperPrice.DAL.Seguridad
{
    public class PermisoDAL
    {
        public List<Permiso> ObtenerPermisos()
        {
            List<Permiso> permisos =
                new List<Permiso>();

            PermisoSimple crear =
                new PermisoSimple();

            crear.Id = 1;
            crear.Codigo = "PP001";
            crear.Nombre = "Crear Producto";

            PermisoSimple modificar =
                new PermisoSimple();

            modificar.Id = 2;
            modificar.Codigo = "PP002";
            modificar.Nombre = "Modificar Producto";

            PermisoCompuesto gestion =
                new PermisoCompuesto();

            gestion.Id = 3;
            gestion.Codigo = "GE051";
            gestion.Nombre = "Gestion Productos";

            gestion.Agregar(crear);
            gestion.Agregar(modificar);

            permisos.Add(gestion);

            return permisos;
        }
    }
}
