using SuperPrice.BLL.Seguridad;
using System;
using System.Windows.Forms;

namespace SuperPrice.Forms
{
    public partial class FrmBitacora : Form
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        private void CargarBitacora()
        {
            BitacoraBLL bitacoraBLL =
                new BitacoraBLL();

            dgvBitacora.DataSource =
                bitacoraBLL.ObtenerBitacora();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }
    }
}
