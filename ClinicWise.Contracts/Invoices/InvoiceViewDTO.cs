namespace ClinicWise.Contracts.Invoices
{
    public class InvoiceViewDTO
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? OutstandingBalance { get; set; }
        public enInvoiceStatus Status { get; set; }
        public string StatusLabel { get; set; }
        public string IssuedBy { get; set; }
    }
}
