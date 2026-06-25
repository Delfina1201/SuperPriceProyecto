using SuperPrice.BE.Seguridad;
using SuperPrice.DAL.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataTable ObtenerBitacora()
        {   
            BitacoraDAL bitacoraDAL =
                new BitacoraDAL();

            return bitacoraDAL.ObtenerBitacora();
        }
    }
}