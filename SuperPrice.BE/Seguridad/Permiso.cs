using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPrice.BE.Seguridad
{
    public abstract class Permiso
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public abstract void Agregar(Permiso permiso);

        public abstract void Quitar(Permiso permiso);
    }
}
