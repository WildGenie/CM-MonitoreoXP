using System;
using System.Windows.Forms;
using AdminAudioVideo.CapaPresentacion;

namespace AdminAudioVideo
{
    internal static class Inicio
    {
        /// <summary>
        ///     Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }
    }
}