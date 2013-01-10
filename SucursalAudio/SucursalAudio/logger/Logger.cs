using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace SucursalAudio.logger
{
    class Logger
    {
        //*************************************************************
        //NOMBRE:        WriteToEventLog
        //PROPOSITO:     Escribir al log de eventos del sistema
        //PARAMETROS:    Entry     - Valor a escribir
        //               AppName   - Nombre de la aplicacion cliente. (Necesario).
        //               EventType - Tipo de entrada, Warning, Information, Error
        //               LogName   - Nombre del log (System, Application, 
        //                           Security son solo lectura) Si no existe, se creara.
        //RETURNS:       True si sea ejecutado correctamente
        //*************************************************************
        public bool WriteToEventLog(string entry, string appName, EventLogEntryType eventType, string logName)
        {
            EventLog objEventLog = new EventLog();
            try
            {
                if (!(EventLog.SourceExists(appName)))
                {
                    EventLog.CreateEventSource(appName, logName);
                }
                objEventLog.Source = appName;
                objEventLog.WriteEntry(entry, eventType);
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }
        }

        // *************************************************************
        //NOMBRE:        WriteToErrorLog
        //PROPOSITO:     Abre o crea un Log de Errores y envia el mensaje de error
        //PARAMETROS:    msg      - mensaje a escribir al log de errores
        //               stkTrace - stack trace del mensaje de error
        //               title    - titulo de la entrada en el archivo de error 
        //RETURNS:       Vacio
        //*************************************************************
        public bool WriteToErrorLog(string msg, string stkTrace, string title)
        {
            try
            {
                string vbCrlf = Environment.NewLine;
                Console.WriteLine(Application.StartupPath);
                if (!(System.IO.Directory.Exists(Application.StartupPath + "\\Errors\\")))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Errors\\");
                }
                FileStream fs = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter s = new StreamWriter(fs);
                s.Close();
                fs.Close();
                FileStream fs1 = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.Append, FileAccess.Write);
                StreamWriter s1 = new StreamWriter(fs1);
                s1.Write("Title: " + title + vbCrlf);
                s1.Write("Message: " + msg + vbCrlf);
                s1.Write("StackTrace: " + stkTrace + vbCrlf);
                s1.Write("Date/Time: " + DateTime.Now.ToString() + vbCrlf);
                s1.Write("===========================================================================================" + vbCrlf);
                s1.Close();
                fs1.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

    }
}
