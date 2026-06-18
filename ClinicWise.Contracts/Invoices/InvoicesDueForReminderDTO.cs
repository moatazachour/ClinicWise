using System;

namespace ClinicWise.Contracts.Invoices
{
    public class InvoicesDueForReminderDTO
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public int PatientID { get; set; }
        public decimal OutstandingBalance { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime IssuedAt { get; set; }
        public int RemindersSentCount { get; set; }
        public DateTime? LastReminderSentAt { get; set; }
    }
}
