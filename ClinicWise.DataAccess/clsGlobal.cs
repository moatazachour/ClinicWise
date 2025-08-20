using System;
using System.Diagnostics;

namespace ClinicWise.DataAccess
{
    public class clsGlobal
    {
        static public void LogError(Exception ex, string SourceName = "ClinicWise")
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            string Message = $"Message Error: {ex.Message}\n" +
                             $"Inner Exception: {ex.InnerException}\n" +
                             $"Stack Trace: {ex.StackTrace}\n" +
                             $"Source: {ex.Source}\n";

            EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
        }
    }
}
