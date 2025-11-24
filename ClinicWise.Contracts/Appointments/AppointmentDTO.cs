using System;

namespace ClinicWise.Contracts.Appointments
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime? Date { get; set; }
        public byte Status { get; set; }
        public int ScheduledByUserID { get; set; }
    }
}
