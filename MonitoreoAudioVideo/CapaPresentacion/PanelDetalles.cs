using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdminAudioVideo.Componentes;

namespace AdminAudioVideo.CapaPresentacion
{
    public partial class PanelDetalles : Form
    {
        Streaming _stream = new Streaming();

        public PanelDetalles(string titulo)
        {
            InitializeComponent();
            this.Text = string.Format("Sucursal en linea: {0}", titulo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                _stream.RecibirStreaming(0,"192.168.10.25", 11000);
                btnStop.Enabled = true;
                btnStart.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stream.DetenerRecepcion();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }
    }
}
