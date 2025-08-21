using System.Diagnostics;

namespace ClinicWise.Global_Classes
{
    static class clsGlobalSettings
    {
        public static int CurrentUserID = 1;

        static public void LogInformation(string Message, string SourceName = "ClinicWise")
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
        }
    }
}
