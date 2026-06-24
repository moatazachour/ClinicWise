using ClinicWise.DataAccess;
using ClinicWise.Service.Jobs;
using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace ClinicWise.Service
{
    public partial class ClinicWiseService : ServiceBase
    {
        private Timer _timer;
        private readonly int _intervalHours;
        public ClinicWiseService()
        {
            InitializeComponent();
            _intervalHours = int.Parse(ConfigurationManager.AppSettings["IntervalHours"]);
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Service has started");
            _timer = new Timer(_intervalHours * 3_600_000);
            _timer.Elapsed += OnTimeElapsed;
            _timer.AutoReset = true;
            _timer.Start();

            Task.Run(() =>
            {
                try { RunAllJobs(); }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                }
            });

        }

        private void OnTimeElapsed(object sender, ElapsedEventArgs args)
        {
            _timer.Stop();
            try
            {
                RunAllJobs();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // replace with real logging later
            }
            finally
            {
                _timer.Start();
            }
        }

        protected override void OnStop()
        {
            Console.WriteLine("Service has stopped");
        }

        private void RunAllJobs()
        {
            new NoShowMarkingJob().Run();
            new AppointmentReminderJob().Run();
            new InvoiceReminderJob().Run();
        }

        public void StartInConsole()
        {
            OnStart(null);
            Console.WriteLine("Press Enter to stop the service...");
            Console.ReadLine();
            OnStop();
            Console.ReadKey();
        }
    }
}
