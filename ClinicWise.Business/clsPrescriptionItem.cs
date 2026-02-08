using ClinicWise.Contracts.PrescriptionItems;
using System;

namespace ClinicWise.Business
{
    public class clsPrescriptionItem
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;

        public int ItemID { get; set; }
        public int MedicalRecordID { get; set; }
        public int MedicamentID { get; set; }
        public stDosageInfo DosageInfo { get; set; }

        public clsPrescriptionItem()
        {
            ItemID = -1;
            MedicalRecordID = -1;
            MedicamentID = -1;
            DosageInfo = new stDosageInfo
            {
                Dosage = string.Empty,
                Frequency = string.Empty,
                Duration = new stDurationPeriod { Days = 0, Months = 0 },
                IsForever = false
            };

            Mode = enMode.AddNew;
        }

        public clsPrescriptionItem(
            int itemID,
            int medicalRecordID,
            int medicamentID,
            stDosageInfo dosageInfo)
        {
            ItemID = itemID;
            MedicalRecordID = medicalRecordID;
            MedicamentID = medicamentID;
            DosageInfo = dosageInfo;

            Mode = enMode.Update;
        }

        private bool _Update()
        {
            throw new NotImplementedException();
        }    }

        private bool _AddNew()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

    }
}
