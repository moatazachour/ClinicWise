using ClinicWise.DataAccess;
using System;
using System.Runtime.CompilerServices;

namespace ClinicWise.Business
{
    public class clsInvoiceReminder
    {
        public int InvoiceReminderID { get; set; }
        public int InvoiceID { get; set; }
        public byte ReminderNumber { get; set; }
        public string RecipientEmail { get; set; }
        public DateTime SentAt { get; set; }

        public clsInvoiceReminder()
        {
            InvoiceReminderID = -1;
            InvoiceID = -1;
            ReminderNumber = 0;
            RecipientEmail = null;
            SentAt = DateTime.MinValue;
        }

        public clsInvoiceReminder(
            int invoiceReminderID,
            int invoiceID,
            byte reminderNumber,
            string recipientEmail,
            DateTime sentAt)
        {
            InvoiceReminderID = invoiceReminderID;
            InvoiceID = invoiceID;
            ReminderNumber = reminderNumber;
            RecipientEmail = recipientEmail;
            SentAt = sentAt;
        }

        public static bool AddNew(int invoiceID, byte reminderNumber, string recipientEmail, DateTime sentAt)
        {
            int reminderId = -1;
            reminderId = clsInvoiceReminderData.AddNew(invoiceID, reminderNumber, recipientEmail, sentAt);

            return reminderId != -1;
        }
    }
}
