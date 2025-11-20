using System;

namespace ClinicWise.Contracts.Appointments
{
    public class AppointmentBasicDTO
    {
        public int AppointmentID { get; set; }
        public string PatientName { get; set; }
        public DateTime? Date { get; set; }
        public string StatusCaption { get; set; }

        public AppointmentBasicDTO(
            int appointmentID, 
            string patientName, 
            DateTime? date, 
            string statusCaption)
        {
            AppointmentID = appointmentID;
            PatientName = patientName;
            Date = date;
            StatusCaption = statusCaption;
        }
    }
}
