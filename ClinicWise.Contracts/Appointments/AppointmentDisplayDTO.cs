using System;

namespace ClinicWise.Contracts.Appointments
{
    public class AppointmentDisplayDTO
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public string DoctorFullLabel { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime? Date { get; set; }
        public string StatusCaption { get; set; }
        public string ScheduledBy { get; set; }

        public AppointmentDisplayDTO(
            int appointmentID, 
            string doctorFullLabel, 
            string patientName, 
            DateTime? date, 
            string statusCaption, 
            string scheduledBy)
        {
            AppointmentID = appointmentID;
            DoctorFullLabel = doctorFullLabel;
            PatientName = patientName;
            Date = date;
            StatusCaption = statusCaption;
            ScheduledBy = scheduledBy;
        }

        public AppointmentDisplayDTO(
            int appointmentID, 
            int doctorID, 
            string doctorFullLabel, 
            int patientID, 
            string patientName, 
            DateTime? date, 
            string statusCaption, 
            string scheduledBy)
        {
            AppointmentID = appointmentID;
            DoctorID = doctorID;
            DoctorFullLabel = doctorFullLabel;
            PatientID = patientID;
            PatientName = patientName;
            Date = date;
            StatusCaption = statusCaption;
            ScheduledBy = scheduledBy;
        }
    }
}
