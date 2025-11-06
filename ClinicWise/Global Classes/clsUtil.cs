using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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

                case enPersonType.Staff:
                    return destinationFolderBase + @"Staff\";

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

        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
