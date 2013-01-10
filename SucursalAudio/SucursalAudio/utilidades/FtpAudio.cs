using System;

using System.Net;
using System.IO;
using System.Diagnostics;
//using Oracle.DataAccess.Client;

namespace SucursalAudio.utilidades
{
    public class FtpAudio
    {
        SucursalAudio.logger.Logger logger = new SucursalAudio.logger.Logger();
        SucursalAudio.configAudio config = new  SucursalAudio.configAudio();

        public void enviaFtp(string nombreArchivo, string nuevoNombre)
        {
            FileInfo fileInf = new FileInfo(nombreArchivo);
            Console.WriteLine(fileInf.Attributes);
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest) FtpWebRequest.Create("ftp://"+config.ftp_direccion+"/" + nuevoNombre + fileInf.Extension);

                reqFTP.Credentials = new NetworkCredential(config.ftp_usuario, config.ftp_pass);
                reqFTP.UsePassive = config.ftp_usarPasivo;
                reqFTP.KeepAlive = false;

                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.UseBinary = true;
                reqFTP.ContentLength = fileInf.Length;

                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                
                FileStream fs = fileInf.OpenRead();

            
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
            
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
            
                strm.Close();
                fs.Close();
                if(fileInf.Exists)
                    fileInf.Delete();

                Console.WriteLine("Archivo " + nuevoNombre + " enviado correctamente al ftp");
            }
            catch(Exception ex)
            {
                logger.WriteToEventLog("ERROR: " + ex.Message +
                                        Environment.NewLine +
                                        "STACK TRACE: " + ex.StackTrace,
                                        "Servicio de envio FTP [enviaFtp]",
                                        EventLogEntryType.Error,
                                        "LogSucursalAudio");
                logger.WriteToErrorLog("ERROR: " + ex.Message,
                                        ex.StackTrace,
                                        "FtpAudio.cs");
                
                Console.WriteLine("Error [enviaFtp]: " + ex.Message);
                Console.WriteLine("StackTrace [enviaFtp]: " + ex.StackTrace);
            }
        }
    }
}
