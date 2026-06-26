using SuperPrice.BE.Seguridad;
using SuperPrice.DAL.Seguridad;
using System;
using System.Data;

namespace SuperPrice.BLL.Seguridad
{
    public class BitacoraBLL
    {
        public void Registrar(Bitacora bitacora)
        {
            BitacoraDAL bitacoraDAL =
                new BitacoraDAL();

            bitacoraDAL.Registrar(bitacora);

            // Actualiza el DVV después de guardar la bitácora
            DVVManager dvvManager =
                new DVVManager();

            dvvManager.ActualizarDVVBitacora();
        }

        public DataTable ObtenerBitacora(
            string usuario,
            string evento,
            DateTime desde,
            DateTime hasta)
        {
            BitacoraDAL bitacoraDAL =
                new BitacoraDAL();

            return bitacoraDAL.ObtenerBitacora(
                usuario,
                evento,
                desde,
                hasta);
        }
    }
}