using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnErrorLog_Click(object sender, EventArgs e)
        {
            int int1 = 10;
            int int2 = 0;
            int intResult;
            try
            {
                intResult = int1 / int2;
            }
            catch (Exception ex)
            {
                ErrorsAndEvents.ErrorLogger el = new ErrorsAndEvents.ErrorLogger();
                el.WriteToErrorLog(ex.Message, ex.StackTrace, "Error");
                MsgBox("Error logged.");
            }

        }

        private void btnEventLog_Click(object sender, EventArgs e)
        {
            int int1 = 10;
            int int2 = 0;
            int intResult;
            try
            {
                intResult = int1 / int2;
            }
            catch (Exception ex)
            {
                ErrorsAndEvents.EventLogger el = new ErrorsAndEvents.EventLogger();
                bool bResult;
                bResult = el.WriteToEventLog(ex.Message, "BXSW", EventLogEntryType.Error, "TestApp");
                if (bResult == true)
                {
                    MessageBox.Show("Event logged.");
                }
                else
                {
                    MessageBox.Show("Event not logged");
                }
            }

        }
        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

    }
}