using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdminAudioVideo.CapaAccesoDatos;
using AdminAudioVideo.Componentes;

namespace AdminAudioVideo.CapaPresentacion
{
    public partial class Principal : Form
    {
        private int _col, _row;
        private ArregloControl[] _arregloControlVilla, _arregloControlCoatza;

        public Principal()
        {
            InitializeComponent();
            //CrearConexion();
        }

        private void mnuItemSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            MetodosDatos metodos = new MetodosDatos();
            
            List<Sucursal> listadoVilla = metodos.ObtenerSucursales("77");
            _arregloControlVilla = new ArregloControl[listadoVilla.Count];

            for (int i = 0; i < _arregloControlVilla.Length; i++)
            {
                _arregloControlVilla[i] = new ArregloControl();
                //TODO crear un Builder para la creacion de multiples componentes
                _arregloControlVilla[i].CrearComponente(spCont.Panel1, _col, _row, i, listadoVilla[i]);
                _col++;
                if (_col == 9)
                {
                    _col = 0;
                    _row++;
                }
            }

            _col = 0;
            _row = 0;

            List<Sucursal> listadoCoatza = metodos.ObtenerSucursales("78");
            _arregloControlCoatza = new ArregloControl[listadoCoatza.Count];

            for (int i = 0; i < _arregloControlCoatza.Length; i++)
            {
                _arregloControlCoatza[i] = new ArregloControl();
                //TODO crear un Builder para la creacion de multiples componentes
                _arregloControlCoatza[i].CrearComponente(spCont.Panel2, _col, _row, i, listadoCoatza[i]);
                _col++;
                if (_col == 9)
                {
                    _col = 0;
                    _row++;
                }
            }

            
        }
    }
}