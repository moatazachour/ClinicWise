using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace ClinicWise.Global_Classes
{
    static class clsGlobalSettings
    {
        public static int CurrentUserID;

        private static string EncryptionKey = "moatazachour2001";

        private static string usernameValue = "Username";
        private static string passwordValue = "Password";

        static public void LogInformation(string Message, string SourceName = "ClinicWise")
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
        }

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\ClinicWise";

            try
            {
                string EncryptedPassword = clsUtil.Encrypt(Password, EncryptionKey);

                Registry.SetValue(keyPath, usernameValue, Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, passwordValue, EncryptedPassword, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                LogInformation(ex.Message);
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\ClinicWise";
            string EncryptedPassword;

            try
            {
                Username = Registry.GetValue(keyPath, usernameValue, null) as string;
                EncryptedPassword = Registry.GetValue(keyPath, passwordValue, null) as string;

                Password = clsUtil.Decrypt(EncryptedPassword, EncryptionKey);

                return true;
            }
            catch (Exception ex)
            {
                LogInformation(ex.Message);
                return false;
            }

        }

    }
}
