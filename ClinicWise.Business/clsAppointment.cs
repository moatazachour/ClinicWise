using ClinicWise.DataAccess;
using System;

namespace ClinicWise.Business
{
    public class clsAppointment
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public enum enAppointmentStatus { Pending = 1, Confirmed = 2, Completed = 3,
                                          Cancelled = 4, Rescheduled = 5, NoShow = 6 }

        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime? Date { get; set; }
        public enAppointmentStatus Status { get; set; }
        public int ScheduledByUserID { get; set; }

        public clsAppointment()
        {
            AppointmentID = -1;
            DoctorID = -1;
            PatientID = -1;
            Date = DateTime.Now;
            Status = enAppointmentStatus.Pending;
            ScheduledByUserID = -1;

            Mode = enMode.AddNew;
        }

        public clsAppointment(
            int appointmentID, 
            int doctorID, 
            int patientID, 
            DateTime? date, 
            enAppointmentStatus status, 
            int scheduledByUserID)
        {
            AppointmentID = appointmentID;
            DoctorID = doctorID;
            PatientID = patientID;
            Date = date;
            Status = status;
            ScheduledByUserID = scheduledByUserID;

            Mode = enMode.Update;
        }


        private bool _Update()
        {
            return clsAppointmentData.Update(AppointmentID, DoctorID, PatientID, Date, (byte)Status, ScheduledByUserID);
        }

        private bool _AddNew()
        {
            AppointmentID = clsAppointmentData.AddNew(DoctorID,  PatientID, Date, (byte)Status, ScheduledByUserID);

            return AppointmentID != -1;
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

        
    }
}
