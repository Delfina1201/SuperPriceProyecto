    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPrice.BLL.Idiomas
{
    public class Etiqueta
    {
        public string Clave { get; set; }

        public string Texto { get; set; }

        public Idioma Idioma { get; set; }
    }
}
