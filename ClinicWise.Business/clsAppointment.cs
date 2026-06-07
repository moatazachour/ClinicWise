using ClinicWise.Business.Services;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.Patients;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public clsAppointment(AppointmentDTO appointmentDTO)
        {
            AppointmentID = appointmentDTO.AppointmentID;
            DoctorID = appointmentDTO.DoctorID;
            PatientID = appointmentDTO.PatientID;
            Date = appointmentDTO.Date;
            Status = (enAppointmentStatus)appointmentDTO.Status;
            ScheduledByUserID = appointmentDTO.ScheduledByUserID;

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

        public static async Task<AppointmentDTO> FindAsync(int appointmentID)
        {
            return await clsAppointmentData.GetByIDAsync(appointmentID);
        }

        public static AppointmentDTO Find(int appointmentID)
        {
            return clsAppointmentData.GetByID(appointmentID);
        }

        public static async Task<AppointmentDisplayDTO> FindDetailedAsync(int appointmentID)
        {
            return await clsAppointmentData.GetDetailedByID(appointmentID);
        }

        public static async Task<List<AppointmentDisplayDTO>> GetAllAsync()
        {
            return await clsAppointmentData.GetAllAsync();
        }

        public static async Task<List<AppointmentDisplayDTO>> GetTodaysAsync()
        {
            return await clsAppointmentData.GetTodaysAsync();
        }

        public static async Task<List<AppointmentDisplayDTO>> GetTomorrowsAsync()
        {
            return await clsAppointmentData.GetTomorrowsAsync();
        }

        public static async Task<List<AppointmentDisplayDTO>> GetThisWeekAppointmentsAsync()
        {
            return await clsAppointmentData.GetThisWeekAppointmentsAsync();
        }

        public static async Task<List<AppointmentDisplayDTO>> GetNextWeekAppointmeentsAsync()
        {
            return await clsAppointmentData.GetNextWeekAppointmeentsAsync();
        }

        public static async Task<List<AppointmentDisplayDTO>> GetThisMonthAppointmentsAsync()
        {
            return await clsAppointmentData.GetThisMonthAppointmentsAsync();
        }

        public static async Task<List<AppointmentDisplayDTO>> GetNextMonthAppointmentsAsync()
        {
            return await clsAppointmentData.GetNextMonthAppointmentsAsync();
        }

        public static async Task<List<AppointmentDisplayDTO>> GetByDoctorAsync(int  doctorId)
        {
            return await clsAppointmentData.GetByDoctorAsync(doctorId);
        }

        public static async Task<List<AppointmentDisplayDTO>> GetNextByDoctorAsync(int doctorId)
        {
            return await clsAppointmentData.GetNextByDoctorAsync(doctorId);
        }

        public async Task<bool> IsPatientAvailable()
        {
            List<AppointmentDisplayDTO> patientNextAppointments = await clsAppointmentData.GetByPatientAsync(this.PatientID);

            if (this.Date.HasValue)
            {
                foreach (var appointment in patientNextAppointments)
                {
                    if (appointment.Date.Equals(this.Date))
                        return false;
                }
            }

            return true;
        }

        public async Task<bool> IsDoctorAvailable()
        {
            List<AppointmentDisplayDTO> doctorNextAppointments = await clsAppointmentData.GetNextByDoctorAsync(this.DoctorID);

            if (this.Date.HasValue)
            {
                foreach (var appointment in doctorNextAppointments)
                {
                    if (appointment.Date.Equals(this.Date))
                        return false;
                }
            }

            return true;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetByPatientAsync(int patientID)
        {
            return await clsAppointmentData.GetByPatientAsync(patientID);
        }

        public static CompleteAppointmentResult Complete(int appointmentID)
        {
            if (!_DoesAppointmentHaveMedicalRecord(appointmentID))
                return new CompleteAppointmentResult(false, "Appointment cannot be completed: no medical record found.");

            if (!clsAppointmentData.Complete(appointmentID))
                return new CompleteAppointmentResult(false, "Appointment completion failed.");

            return new CompleteAppointmentResult(true);
        }

        private static bool _DoesAppointmentHaveMedicalRecord(int appointmentID)
        {
            return clsMedicalRecordData.DoesThisAppointmentHaveMedicalRecord(appointmentID);
        }

        public static void MarkNoShowAfter(int noShowThresholdMinutes)
        {
            List<AppointmentDisplayDTO> noShowAppointments = clsAppointmentData.MarkAndGetNoShowAppointments(noShowThresholdMinutes);

            _SendNoShowEmail(noShowAppointments);
        }

        private static void _SendNoShowEmail(List<AppointmentDisplayDTO> noShowAppointments)
        {
            string to;
            string subject;
            string body;

            foreach (AppointmentDisplayDTO appointmentDisplay in noShowAppointments)
            {
                to = appointmentDisplay.PatientEmail;

                if (string.IsNullOrWhiteSpace(to))
                    continue;

                subject = "Missed Appointment Notification";

                body = $@"Dear {appointmentDisplay.PatientName},

We noticed that you missed your appointment scheduled for {appointmentDisplay.Date:dddd, MMMM dd, yyyy} at {appointmentDisplay.Date:hh:mm tt} with Dr. {appointmentDisplay.DoctorFullLabel}.

If you would like to reschedule, please contact us at your earliest convenience.

We hope to see you soon.

Best regards,
ClinicWise Team";
                EmailService.SendEmail(to, subject, body);
            }
        }
    }

    public class CompleteAppointmentResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public CompleteAppointmentResult(bool isSuccess, string message = "Success")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
