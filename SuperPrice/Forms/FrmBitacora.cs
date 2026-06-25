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
            MessageBox.Show(
    "Usuario: " + txtUsuario.Text +
    "\nEvento: " + txtEvento.Text);

            MessageBox.Show("Evento = [" + txtEvento.Text + "]");

            BitacoraBLL bitacoraBLL =
                new BitacoraBLL();

            dgvBitacora.DataSource =
                bitacoraBLL.ObtenerBitacora(
                    txtUsuario.Text,
                    txtEvento.Text,
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date.AddDays(1).AddSeconds(-1));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        private void txtEvento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
