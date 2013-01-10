using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace ErrorsAndEvents
{
    static class ErrorLogger
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    // *************************************************************
    //NAME:          WriteToErrorLog
    //PURPOSE:       Open or create an error log and submit error message
    //PARAMETERS:    msg - message to be written to error file
    //               stkTrace - stack trace from error message
    //               title - title of the error file entry
    //RETURNS:       Nothing
    //*************************************************************
        public void WriteToErrorLog(string msg, string stkTrace, string title)
        {
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
            s1.Write("Title: " + title + vbCrLf);
            s1.Write("Message: " + msg + vbCrLf);
            s1.Write("StackTrace: " + stkTrace + vbCrLf);
            s1.Write("Date/Time: " + DateTime.Now.ToString() + vbCrLf);
            s1.Write("===========================================================================================" + vbCrLf);
            s1.Close();
            fs1.Close();
        }

    }
}