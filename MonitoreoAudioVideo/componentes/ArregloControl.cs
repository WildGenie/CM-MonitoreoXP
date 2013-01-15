using System;
using System.Windows.Forms;
using System.Drawing;
using AdminAudioVideo.CapaPresentacion;

namespace AdminAudioVideo.componentes
{
    public class ArregloControl
    {
        //private Form HostForm;
        private SplitContainer _hostForm;
        private readonly int[] _posElem1 = new[] { 0, 120, 240, 360, 480, 600, 720, 840, 960, 1080, 1200 };
        private readonly int[] _posElem2 = new[] { 50, 170, 290, 410, 530, 650, 770, 890, 1010, 1130, 1250 };
        private readonly int[] _posRowBoton = new[] { 70, 190, 310 };
        private readonly int[] _posRowLabel = new[] { 30, 150, 270 };
        public int _index, _col, _row;
        public string _status;

        public void CrearComponente(SplitContainer host, int columna, int fila, int indice)
        {
            _hostForm = host;
            _index = indice;
            _col = columna;
            _row = fila;

            AgregarEtiqueta("Sucursal");
            AgregarBoton("Cam.", ClickVideo, 1);
            AgregarBoton("Aud.", ClickAudio, 2);
        }

        private Button AgregarBoton(string name, EventHandler evento, int orden)
        { 
            Button aButton = new Button();
            _hostForm.Panel1.Controls.Add(aButton);
            aButton.Top = _posRowBoton[_row];
            aButton.Left = orden == 1 ? _posElem1[_col] : _posElem2[_col];
            aButton.Size = new Size(50, 50);
            aButton.Tag = _index;
            aButton.Text = string.Format("{0} {1}", name, _index);
            aButton.Click += evento;
            return aButton;
        }

        private Label AgregarEtiqueta(string texto)
        {
            Label etiqueta = new Label();
            _hostForm.Panel1.Controls.Add(etiqueta);
            etiqueta.Top = _posRowLabel[_row];
            etiqueta.Left = _posElem1[_col];
            etiqueta.Text = string.Format("{0} {1}", texto, _index);
            etiqueta.Tag = _index;
            etiqueta.TextAlign = ContentAlignment.MiddleCenter;
            etiqueta.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            
            return etiqueta;
        }


        private void ClickVideo(Object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Activando Camara {0}", ((Button)sender).Text));
            //TODO implementar elementos DAO para almacenar los datos de todos las sucursales
            PanelDetalles detalle = new PanelDetalles(string.Format("Sucursal {0}", _index));
            detalle.Show();
        }

        private void ClickAudio(Object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Activando Audio {0}", ((Button)sender).Text));
        }


    }
}
