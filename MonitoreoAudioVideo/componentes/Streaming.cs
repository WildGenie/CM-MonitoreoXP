using System;
using System.Net;
using LumiSoft.Net.UDP;
using LumiSoft.Net.Codec;
using LumiSoft.Media.Wave;

namespace AdminAudioVideo.Componentes
{
    class Streaming
    {
        private WaveOut _waveOut;
        private UdpServer _servidorUdp;

        public void DetenerRecepcion()
        {
            _waveOut.Dispose();
            _servidorUdp.Stop();
        }

        public void RecibirStreaming(int numberDevice, string ipEmisor, int puerto)
        {
            try
            {
                _waveOut = new WaveOut(WaveOut.Devices[numberDevice], 8000, 16, 1);
                _servidorUdp = new UdpServer();
                _servidorUdp.Bindings = new IPEndPoint[] { new IPEndPoint(IPAddress.Parse(ipEmisor), (int)puerto) };
                _servidorUdp.PacketReceived += new PacketReceivedHandler(recibirPaquetes_ServidorUdp);
                _servidorUdp.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        private void recibirPaquetes_ServidorUdp(UdpPacket_eArgs e)
        {
            try
            {
                Console.WriteLine("recibiendo...");
                // Decompress data.
                byte[] decodedData = G711.Decode_uLaw(e.Data, 0, e.Data.Length);

                // We just play received packet.
                _waveOut.Play(decodedData, 0, decodedData.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error [recibirPaquetes_ServidorUdp]: {0}", ex.Message);
                Console.WriteLine("StackTrace [recibirPaquetes_ServidorUdp]: {0}", ex.StackTrace);
            }
        }
    }
}
