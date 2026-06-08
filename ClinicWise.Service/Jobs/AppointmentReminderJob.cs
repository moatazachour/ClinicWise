using ClinicWise.Business;

namespace ClinicWise.Service.Jobs
{
    public class AppointmentReminderJob
    {
        public void Run()
        {
            clsAppointment.ProcessAppointmentReminders();
        }
    }
}
