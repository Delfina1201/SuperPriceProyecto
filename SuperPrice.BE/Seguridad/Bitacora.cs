using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPrice.BE.Seguridad
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }

        public DateTime FechaHora { get; set; }

        public string Usuario { get; set; }

        public string Evento { get; set; }

        public string Descripcion { get; set; }
    }
}
