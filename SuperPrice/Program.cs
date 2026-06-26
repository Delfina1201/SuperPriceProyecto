using System;
using System.Windows.Forms;
using SuperPrice.Forms;
using SuperPrice.BLL.Seguridad;

namespace SuperPrice
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            VerificadorIntegridad verificador = new VerificadorIntegridad();

            if (!verificador.Verificar())
            {
                MessageBox.Show("Se detectó un error en la integridad de la base de datos.");
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}
