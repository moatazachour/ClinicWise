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
            _timer = new Timer(_intervalHours * 60_000); // To change to hour after, currently it is in minutes
            _timer.Elapsed += OnTimeElapsed;
            _timer.AutoReset = true;
            _timer.Start();

            Task.Run(() =>
            {
                try { RunAllJobs(); }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // replace with real logging later
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
