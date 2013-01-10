using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ErrorsAndEvents
{
    class EventLogger
    {
    //*************************************************************
    //NAME:          WriteToEventLog
    //PURPOSE:       Write to Event Log
    //PARAMETERS:    Entry - Value to Write
    //               AppName - Name of Client Application. Needed 
    //               because before writing to event log, you must 
    //               have a named EventLog source. 
    //               EventType - Entry Type, from EventLogEntryType 
    //               Structure e.g., EventLogEntryType.Warning, 
    //               EventLogEntryType.Error
    //               LogNam1e: Name of Log (System, Application; 
    //               Security is read-only) If you 
    //               specify a non-existent log, the log will be
    //               created

    //RETURNS:       True if successful
    //*************************************************************
        public bool WriteToEventLog(string entry, string appName, EventLogEntryType eventType, string logName)
        {
            EventLog objEventLog = new EventLog();
            try
            {
                if (!(EventLog.SourceExists(appName)))
                {
                    EventLog.CreateEventSource(appName, LogName);
                }
                objEventLog.Source = appName;
                objEventLog.WriteEntry(entry, eventType);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }


    }
}
