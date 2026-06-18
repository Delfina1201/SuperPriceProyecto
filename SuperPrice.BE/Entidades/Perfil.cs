using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SuperPrice.BE.Entidades
{
    public class Perfil
    {
        public int IdPerfil { get; set; }

        public string Nombre { get; set; }

        public List<Permiso> Permisos { get; set; }

        public Perfil()
        {
            Permisos = new List<Permiso>();
        }
    }
}
