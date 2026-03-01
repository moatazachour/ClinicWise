namespace ClinicWise.Contracts.MedicalRecords
{
    public class MedicalRecordFullViewDTO
    {
        public int RecordID { get; set; }
        public int AppointmentID { get; set; }
        public string VisitType { get; set; }
        public string DescriptionOfVisit { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }

        public MedicalRecordFullViewDTO(
            int recordID,
            int appointmentID,
            string visitType,
            string descriptionOfVisit,
            string diagnosis,
            string additionalNotes)
        {
            RecordID = recordID;
            AppointmentID = appointmentID;
            VisitType = visitType;
            DescriptionOfVisit = descriptionOfVisit;
            Diagnosis = diagnosis;
            AdditionalNotes = additionalNotes;
        }
    }
}
