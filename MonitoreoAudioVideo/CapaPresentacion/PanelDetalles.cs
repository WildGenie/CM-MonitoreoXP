using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminAudioVideo.CapaPresentacion
{
    public partial class PanelDetalles : Form
    {
        public PanelDetalles(string titulo)
        {
            InitializeComponent();
            this.Text = string.Format("Sucursal en linea: {0}", titulo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
