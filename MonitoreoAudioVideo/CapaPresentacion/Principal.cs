using System;
using System.Windows.Forms;
using AdminAudioVideo.Properties;
using AdminAudioVideo.componentes;
using Oracle.DataAccess.Client;

namespace AdminAudioVideo.CapaPresentacion
{
    public partial class Principal : Form
    {
        private readonly config _config = new config();
        private int _col, _row;
        private ArregloControl[] _arregloControl;

        public Principal()
        {
            InitializeComponent();
            CrearConexion();
        }

        private void CrearConexion()
        {
            try
            {
                OracleConnection conec = new OracleConnection(_config.connOracle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void mnuItemSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelDetalles pnlDetalles = new PanelDetalles("jaja");
            pnlDetalles.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            _arregloControl = new ArregloControl[11];

            for (int i = 0; i < _arregloControl.Length; i++)
            {
                _arregloControl[i] = new ArregloControl();
                //TODO crear un Builder para la creacion de multiples componentes
                _arregloControl[i].CrearComponente(spCont, _col, _row, i);
                _arregloControl[i]._status = i%2==0 ? "activo" : "inactivo";
                _col++;
                if (_col == 7)
                {
                    _col = 0;
                    _row++;
                }
            }

            foreach (Control control in spCont.Panel1.Controls)
            {
                if(control is Button)
                    Console.WriteLine(control.Tag);
                
            }
        }
    }
}