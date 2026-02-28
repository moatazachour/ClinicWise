using ClinicWise.Contracts.Medicaments;

namespace ClinicWise.Contracts.PrescriptionItems
{
    public class PrescriptionItemDisplayDTO
    {
        public int ItemID { get; set; }
        public int MedicalRecordID { get; set; }
        public int MedicamentID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public enDosageForm DosageForm { get; set; }
        public stDosageInfo DosageInfo { get; set; }

        public PrescriptionItemDisplayDTO(
            int itemID, 
            int medicalRecordID, 
            int medicamentID, 
            string brand, 
            string name, 
            enDosageForm dosageForm, 
            stDosageInfo dosageInfo)
        {
            ItemID = itemID;
            MedicalRecordID = medicalRecordID;
            MedicamentID = medicamentID;
            Brand = brand;
            Name = name;
            DosageForm = dosageForm;
            DosageInfo = dosageInfo;
        }
    }
}
