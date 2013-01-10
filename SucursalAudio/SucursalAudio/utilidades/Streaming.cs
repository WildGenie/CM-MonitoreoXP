using System;

using System.Net;
using System.Diagnostics;

using LumiSoft.Net.UDP;
using LumiSoft.Net.Codec;
using LumiSoft.Media.Wave;

namespace SucursalAudio.utilidades
{
    class Streaming
    {
        private WaveIn waveIn = null;
        private WaveOut waveOut = null;
        private UdpServer servidorUdp = null;
        private IPEndPoint puntoDestino = null;
        private int numeroDispositivo = 0;
        SucursalAudio.logger.Logger logger = new SucursalAudio.logger.Logger();
        
        public void enviarStreaming(int numberDevice, string ipReceptor, string ipEmisor, int puerto)
        {
            try
            {
                numeroDispositivo = numberDevice;
                servidorUdp = new UdpServer();
                servidorUdp.Bindings = new IPEndPoint[] { new IPEndPoint(IPAddress.Parse(ipEmisor), (int)puerto) };
                servidorUdp.Start();
                
                puntoDestino = new IPEndPoint(IPAddress.Parse(ipReceptor), (int)puerto);

                waveIn = new WaveIn(WaveIn.Devices[numberDevice], 8000, 16, 1, 400);
                waveIn.BufferFull += new BufferFullHandler(waveIn_BufferFull);
                waveIn.Start();
            }
            catch (Exception ex)
            {
                logger.WriteToEventLog("ERROR: " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Servicio de envio de streaming [enviarStreaming]",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "Streaming.cs");

                Console.WriteLine("Error [enviarStreaming]: " + ex.Message);
                Console.WriteLine("StackTrace [enviarStreaming]: " + ex.StackTrace);
            }
        }
        public void detenerEnvio()
        {
            waveIn.Stop();
            servidorUdp.Stop();
        }

        public void recibirStreaming(int numberDevice, string ipEmisor, int puerto)
        {
            waveOut = new WaveOut(WaveOut.Devices[numberDevice], 8000, 16, 1);
            servidorUdp = new UdpServer();
            servidorUdp.Bindings = new IPEndPoint[] { new IPEndPoint(IPAddress.Parse(ipEmisor), (int)puerto) };
            servidorUdp.PacketReceived += new PacketReceivedHandler(recibirPaquetes_ServidorUdp);
            servidorUdp.Start();
        }

        private void waveIn_BufferFull(byte[] buffer)
        {
            try
            {
                //Compress data
                byte[] encodedData = null;
                encodedData = G711.Encode_uLaw(buffer, 0, buffer.Length);
                
                // We just sent buffer to target end point.
                servidorUdp.SendPacket(encodedData, 0, encodedData.Length, puntoDestino);
            }
            catch (Exception ex)
            {
                logger.WriteToEventLog("ERROR: " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Servicio de envio de streaming [WaveBufferFull]",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "Streaming.cs");

                Console.WriteLine("Error [WaveBufferFull]: " + ex.Message);
                Console.WriteLine("StackTrace [WaveBufferFull]: " + ex.StackTrace);
            }

        }

        private void recibirPaquetes_ServidorUdp(UdpPacket_eArgs e)
        {
            try
            {
                // Decompress data.
                byte[] decodedData = null;
                decodedData = G711.Decode_uLaw(e.Data, 0, e.Data.Length);

                // We just play received packet.
                waveOut.Play(decodedData, 0, decodedData.Length);
            }
            catch (Exception ex)
            {
                /*logger.WriteToEventLog("ERROR : " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Servicio de streaming (Recepcion)",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "Streaming.cs");*/
                Console.WriteLine("Error [recibirPaquetes_ServidorUdp]: " + ex.Message);
                Console.WriteLine("StackTrace [recibirPaquetes_ServidorUdp]: " + ex.StackTrace);
            }
        }
    }
}
