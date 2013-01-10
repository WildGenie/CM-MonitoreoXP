using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace SucursalAudio
{
    [RunInstaller(true)]
    public partial class ProyectoInstalador : Installer
    {
        public ProyectoInstalador()
        {
            InitializeComponent();
        }
    }
}
