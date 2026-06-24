using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPrice.BE.Seguridad;
using SuperPrice.DAL.Seguridad;


namespace SuperPrice.BLL.Seguridad
{
    public class PermisoBLL
    {
        private PermisoDAL permisoDAL;

        public PermisoBLL()
        {
            permisoDAL = new PermisoDAL();
        }

        public List<Permiso> ObtenerPermisos()
        {
            return permisoDAL.ObtenerPermisos();
        }
    }
}