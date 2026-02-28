using ClinicWise.Contracts.Medicaments;

namespace ClinicWise.Contracts.PrescriptionItems
{
    public class PrescriptionItemDTO
    {
        public int ItemID { get; set; }
        public int MedicalRecordID { get; set; }
        public int MedicamentID { get; set; }
        public stDosageInfo DosageInfo { get; set; }
    }
}
