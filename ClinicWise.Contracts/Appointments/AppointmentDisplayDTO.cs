using System;

namespace ClinicWise.Contracts.Appointments
{
    public class AppointmentDisplayDTO
    {
        public int AppointmentID { get; set; }
        public string DoctorFullLabel { get; set; }
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
    }
}
