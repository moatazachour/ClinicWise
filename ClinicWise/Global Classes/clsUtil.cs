using System;
using System.IO;
using System.Windows.Forms;

namespace ClinicWise.Global_Classes
{
    public class clsUtil
    {
        private static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        private static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    clsGlobalSettings.LogInformation(ex.Message);
                    return false;
                }
            }

            return true;
        }

        private static string ReplaceFileNameWithGUID(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }

        private static string GetDestinationFolder(string destinationFolderBase, enPersonType personType)
        {
            switch (personType)
            {
                case enPersonType.Doctor:
                    return destinationFolderBase + @"Doctors\";

                case enPersonType.Patient:
                    return destinationFolderBase + @"Patients\";

                case enPersonType.Guardian:
                    return destinationFolderBase + @"Guardians\";

                default:
                    return destinationFolderBase;
            }
        }

        public static bool CopyImageToProjectImageFolder(ref string sourceFile, enPersonType personType)
        {
            string DestinationFolderBase = @"C:\ClinicWise-Images\";

            string DestinationFolder = GetDestinationFolder(DestinationFolderBase, personType);

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        
    }
}
