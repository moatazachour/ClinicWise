using ClinicWise.Business;
using System.Configuration;

namespace ClinicWise.Service.Jobs
{
    public class NoShowMarkingJob
    {
        private readonly int _noShowThresholdMinutes;

        public NoShowMarkingJob()
        {
            _noShowThresholdMinutes = int.Parse(ConfigurationManager.AppSettings["NoShowThresholdMinutes"]);
        }

        public void Run()
        {
            clsAppointment.MarkNoShowAfter(_noShowThresholdMinutes);
        }
    }
}
