using System;

namespace ClinicWise.Contracts.Payments
{
    public class PaymentViewDTO
    {
        public int PaymentID { get; set; }
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public enPaymentMethod Method { get; set; }
        public string MethodLabel { get; set; }
        public decimal AmountPaid { get; set; }
        public int RecordedByUserID { get; set; }
        public string RecordedBy {  get; set; }
    }
}
