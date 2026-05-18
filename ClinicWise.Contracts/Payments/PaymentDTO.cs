using System;

namespace ClinicWise.Contracts.Payments
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime PaymentDate { get; set; }
        public enPaymentMethod Method { get; set; }
        public decimal AmountPaid { get; set; }
        public int RecordedByUserID { get; set; }
    }
}
