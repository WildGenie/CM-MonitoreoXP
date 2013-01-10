namespace SucursalAudio
{
    partial class ProyectoInstalador
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.instaladorServicioProcesos = new System.ServiceProcess.ServiceProcessInstaller();
            this.servicioInstalado = new System.ServiceProcess.ServiceInstaller();
            // 
            // instaladorServicioProcesos
            // 
            this.instaladorServicioProcesos.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.instaladorServicioProcesos.Password = null;
            this.instaladorServicioProcesos.Username = null;
            // 
            // servicioInstalado
            // 
            this.servicioInstalado.Description = "Cliente de audio bluetooth para sucursales del Laboratorio Chontalpa";
            this.servicioInstalado.DisplayName = "Servicio de Sucursal Audio";
            this.servicioInstalado.ServiceName = "Servicio Cliente Sucursal Audio";
            this.servicioInstalado.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProyectoInstalador
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.instaladorServicioProcesos,
            this.servicioInstalado});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller instaladorServicioProcesos;
        private System.ServiceProcess.ServiceInstaller servicioInstalado;
    }
}