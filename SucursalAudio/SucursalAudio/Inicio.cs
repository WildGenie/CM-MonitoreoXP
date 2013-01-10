using System;
using System.ServiceProcess;
using System.Threading;

namespace SucursalAudio
{
    static class Inicio
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]        

        static void Main()
        {
            #if(!DEBUG)
                //If the mode is in debugging
                //create a new service instance
                Servicio myService = new Servicio();
                //call the start method - this will start the Timer.
                myService.Iniciar();
                //Set the Thread to sleep
                Thread.Sleep(Timeout.Infinite);
                //Call the Stop method-this will stop the Timer.
                //myService.Detener();
            #else
                //The following is the default code - You may fine tune
                //the code to create one instance of the service on the top
                //and use the instance variable in both debug and release mode
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new Servicio() 
			    };
                ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}
