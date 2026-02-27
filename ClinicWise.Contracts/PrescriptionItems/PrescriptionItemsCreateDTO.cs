namespace ClinicWise.Contracts.PrescriptionItems
{
    public class PrescriptionItemsCreateDTO
    {
        public int MedicalRecordID { get; set; }
        public int MedicamentID { get; set; }
        public stDosageInfo DosageInfo { get; set; }

        public PrescriptionItemsCreateDTO(
            int medicalRecordID,
            int medicamentID,
            stDosageInfo dosageInfo) 
        { 
            MedicalRecordID = medicalRecordID;
            MedicamentID = medicamentID;
            DosageInfo = dosageInfo;
        }
    }
}
