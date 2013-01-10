using System;
using System.Windows.Forms;

namespace SucursalAudio.admin
{
    public partial class administrador : Form
    {
        public SucursalAudio.utilidades.FtpAudio ftpAudio = new SucursalAudio.utilidades.FtpAudio();

        public administrador()
        {
            InitializeComponent();
            this.Hide();
        }

        private void iconoAdmin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //mostramos el formulario
            mostrarAdmin();
        }

        private void administrador_Resize(object sender, EventArgs e)
        {
            //Si el estado actual de la ventana es "minimizado"...
            if(this.WindowState == FormWindowState.Minimized) {
                //Ocultamos el formulario
                this.Hide();
            }
        }

        private void administrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cancelamos el evento del formulario
            e.Cancel = true;
            //minimizamos el formulario
            this.WindowState = FormWindowState.Minimized;
        }

        private void configMenu_Click(object sender, EventArgs e)
        {
            mostrarAdmin();
        }

        public void mostrarAdmin()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ftpAudio.enviaFtp(null, null);
        }
    }
}
