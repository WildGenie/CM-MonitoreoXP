using System;

using NAudio.Wave;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace SucursalAudio.utilidades
{
    public class capturaAudio
    {
        //private BufferedWaveProvider bwp;
        WaveInEvent wi;
        //WaveOutEvent wo;
        string tempFile;
        WaveFileWriter writer;
        DateTime hoy            = DateTime.Now;
        FtpAudio ftpAudio       = new FtpAudio();
        Streaming streaming     = new Streaming();
        int deviceBluetooth     = 0;
        SucursalAudio.configAudio config = new SucursalAudio.configAudio();
        SucursalAudio.logger.Logger logger = new SucursalAudio.logger.Logger();
        Thread hilo;
        String ipLocal;

        public void iniciarCaptura()
        {
            try
            {
                /*WaveInCapabilities capabilities;

                for (int numberDevice = 0; numberDevice < WaveIn.DeviceCount; numberDevice++)
                {
                    capabilities = WaveIn.GetCapabilities(numberDevice);
                    Console.WriteLine("Producto->" + capabilities.ProductName.ToUpper().Trim());
                    if (capabilities.ProductName.ToUpper().Trim().Contains("BLUETOOTH"))
                    {
                        deviceBluetooth = numberDevice;
                        break;
                    }
                }*/

                foreach (IPAddress ip in System.Net.Dns.GetHostAddresses(""))
                {
                    if (Regex.IsMatch(ip.ToString(), @"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"))
                    {
                        ipLocal = ip.ToString();
                    }
                }                    

                wi = new WaveInEvent();
                wi.BufferMilliseconds = 1000;
                wi.DeviceNumber = deviceBluetooth;
                wi.WaveFormat = new WaveFormat(44100, 2);
                wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
                wi.StartRecording();

                /*wo = new WaveOutEvent();
                bwp = new BufferedWaveProvider(wi.WaveFormat);
                bwp.DiscardOnBufferOverflow = true;
                wo.Init(bwp);
                wo.Play();*/
                
                tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");
                writer = new WaveFileWriter(tempFile, wi.WaveFormat);
                
                hilo = new Thread(new ThreadStart(iniciarStreaming));
                hilo.Start();
            }
            catch (Exception ex) 
            {
                logger.WriteToEventLog("ERROR: " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Servicio de captura de audio [iniciarCaptura]",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "capturaAudio.cs");
                Console.WriteLine("Error [iniciarCaptura]->" + ex.Message);
            }
        }

        public void iniciarStreaming()
        {
            try{
                streaming.enviarStreaming(deviceBluetooth, config.ip_remota, ipLocal, 11000);
            }
            catch (Exception ex)
            {
                logger.WriteToEventLog("ERROR: " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Servicio de envio de streaming [iniciarStreaming]",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "capturaAudio.cs");
                Console.WriteLine("Error [iniciarStreaming]->" + ex.Message);
            }
        }

        void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            try
            {
                //bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
                if (writer != null && writer.CanWrite)
                {
                    writer.Write(e.Buffer, 0, e.BytesRecorded);
                    if (((writer.Length / 1024) / 1024) >= 3)
                    {
                        //finaliza la grabacion.
                        writer.Close();
                        writer = null;

                        //se envia al ftp y se elimina el archivo
                        DateTime fecha = DateTime.Now;
                        string nuevoNombre = "AUD_" + fecha.Day + fecha.Month + fecha.Year +
                                             "_" + fecha.Hour + fecha.Minute + fecha.Second;
                        ftpAudio.enviaFtp(tempFile, nuevoNombre);

                        //se crea un nuevo archivo de audio
                        tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");
                        //inicia la grabacion.
                        writer = new WaveFileWriter(tempFile, wi.WaveFormat);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.WriteToEventLog("ERROR: " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Servicio de captura de audio [wi_dataAvailable]",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "capturaAudio.cs");
                Console.WriteLine("Error [wi_dataAvailable]: " + ex.Message);
                Console.WriteLine("StackTrace [wi_dataAvailable]: " + ex.StackTrace);
            }
        }

        public void finalizarCaptura()
        {
            writer.Close();
            wi.StopRecording();
            streaming.detenerEnvio();
            hilo.Abort();
        }

    }
}
