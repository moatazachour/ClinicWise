using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.PrescriptionItems;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsPrescriptionItem
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;

        public int ItemID { get; set; }
        public int MedicalRecordID { get; set; }
        public int MedicamentID { get; set; }
        public MedicamentDTO Medicament
        {
            get
            {
                return clsMedicament.Find(MedicamentID);
            }
        }

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
            return clsPrescriptionItemData.Update(ItemID, MedicalRecordID, MedicamentID, DosageInfo);
        }

        private bool _AddNew()
        {
            ItemID = clsPrescriptionItemData.AddNew(MedicalRecordID, MedicamentID, DosageInfo);

            return ItemID != -1;
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

        public static bool SaveItems(List<clsPrescriptionItem> medicalRecordNewPrescriptions, int medicalRecordID)
        {
            List<PrescriptionItemsCreateDTO> prescriptionItemDTOs = medicalRecordNewPrescriptions
                                                                .Select(prescription => new PrescriptionItemsCreateDTO(
                                                                    medicalRecordID,
                                                                    prescription.MedicamentID,
                                                                    prescription.DosageInfo)).ToList();

            bool isPrescriptionsAddedSuccessfully = clsPrescriptionItemData.AddNewItems(prescriptionItemDTOs);

            if (isPrescriptionsAddedSuccessfully)
                medicalRecordNewPrescriptions.ForEach(prescriptionItem => prescriptionItem.Mode = enMode.Update);

            return isPrescriptionsAddedSuccessfully;
        }

        public static async Task<List<PrescriptionItemDisplayDTO>> GetAllByMedicalRecordAsync(int medicalRecordID)
        {
            return await clsPrescriptionItemData.GetAllByMedicalRecordAsync(medicalRecordID);
        }
    }
}
