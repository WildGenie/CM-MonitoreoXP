using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace SucursalAudio
{
    public partial class Servicio : ServiceBase
    {
        SucursalAudio.utilidades.capturaAudio capturaAudio = new SucursalAudio.utilidades.capturaAudio();
        SucursalAudio.logger.Logger logger = new SucursalAudio.logger.Logger();

        public Servicio()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.Iniciar();
        }

        protected override void OnStop()
        {
            this.Detener();
        }

        public void Iniciar()
        {
            logger.WriteToEventLog("Se ha iniciado el servicio de Sucursal Audio Bluetooth.",
                                    "Servicio Audio Bluetooth",
                                    EventLogEntryType.Information,
                                    "LogSucursalAudio");
            
            try
            {
                //Iniciar la captura de audio, envio por ftp y envio por streaming.
                capturaAudio.iniciarCaptura();
                
                //Log de inicio de evento
                logger.WriteToEventLog("INFO: Comenzó la grabación del audio via Bluetooth.",
                                        "Captura audio, envio ftp y streaming",
                                        EventLogEntryType.SuccessAudit,
                                        "LogSucursalAudio");
            }
            catch (Exception ex)
            {
                logger.WriteToEventLog("ERROR: " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Captura audio, envio ftp y streaming [Iniciar]",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "CapturaAudio.cs");
                Console.WriteLine("Error[Iniciar]: " + ex.Message);
                Console.WriteLine("StackTrace[Iniciar]: " + ex.StackTrace);
            }
        }

        public void Detener()
        {
            //Finaliza o detiene la captura de audio, envio por ftp y envio por streaming.
            capturaAudio.finalizarCaptura();

            //Log por detencion de servicio
            logger.WriteToEventLog("Se ha detenido el servicio de Sucursal Audio Bluetooth.",
                                    "Servicio Audio Bluetooth",
                                    EventLogEntryType.Information,
                                    "LogSucursalAudio");
        }
    }
}
