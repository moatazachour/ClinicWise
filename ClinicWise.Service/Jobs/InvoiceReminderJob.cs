using ClinicWise.Business;
using System.Configuration;

namespace ClinicWise.Service.Jobs
{
    public class InvoiceReminderJob
    {
        private readonly byte _invoiceReminderMaxCount;
        private readonly byte _invoiceReminderIntervalDays;

        public InvoiceReminderJob()
        {
            _invoiceReminderMaxCount = byte.Parse(ConfigurationManager.AppSettings["InvoiceReminderMaxCount"]);
            _invoiceReminderIntervalDays = byte.Parse(ConfigurationManager.AppSettings["InvoiceReminderIntervalDays"]);
        }

        public void Run()
        {
            clsInvoice.ProcessInvoiceReminders(_invoiceReminderMaxCount, _invoiceReminderIntervalDays);
        }
    }
}
