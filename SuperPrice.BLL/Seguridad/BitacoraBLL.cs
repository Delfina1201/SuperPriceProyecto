using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPrice.BE.Seguridad;
using SuperPrice.DAL.Seguridad;

namespace SuperPrice.BLL.Seguridad
{
    public class BitacoraBLL
    {
        public void Registrar(Bitacora bitacora)
        {
            BitacoraDAL bitacoraDAL =
                new BitacoraDAL();

            bitacoraDAL.Registrar(
                bitacora);
        }
    }
}