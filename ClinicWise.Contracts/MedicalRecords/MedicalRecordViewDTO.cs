namespace ClinicWise.Contracts.MedicalRecords
{
    public class MedicalRecordViewDTO
    {
        public int RecordID { get; set; }
        public int AppointmentID { get; set; }
        public string VisitType { get; set; }
        public string DescriptionOfVisit { get; set; }
        public string Diagnosis { get; set; }

        public MedicalRecordViewDTO(
            int recordID,
            int appointmentID,
            string visitType,
            string descriptionOfVisit,
            string diagnosis)
        {
            RecordID = recordID;
            AppointmentID = appointmentID;
            VisitType = visitType;
            DescriptionOfVisit = descriptionOfVisit;
            Diagnosis = diagnosis;
        }
    }
}
