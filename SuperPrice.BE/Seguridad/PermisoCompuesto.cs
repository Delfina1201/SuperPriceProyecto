using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPrice.BE.Seguridad
{
    using System.Collections.Generic;

    namespace SuperPrice.BE.Seguridad
    {
        public class PermisoCompuesto : Permiso
        {
            public List<Permiso> Hijos { get; set; }

            public PermisoCompuesto()
            {
                Hijos = new List<Permiso>();
            }

            public override void Agregar(Permiso permiso)
            {
                Hijos.Add(permiso);
            }

            public override void Quitar(Permiso permiso)
            {
                Hijos.Remove(permiso);
            }
        }
    }
}
