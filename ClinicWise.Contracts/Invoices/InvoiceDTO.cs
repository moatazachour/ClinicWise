using System;

namespace ClinicWise.Contracts.Invoices
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal? DiscountPercent { get; set; }
        public enDiscountType? DiscountType { get; set; }
        public int? DiscountAuthorizedByUserID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? OutstandingBalance { get; set; }
        public enInvoiceStatus Status { get; set; }
        public int? IssuedByUserID { get; set; }
        public DateTime? IssuedAt { get; set; }
        public int? VoidedByUserID { get; set; }
        public string VoidReason { get; set; }
        public string Notes { get; set; }

        //public InvoiceDTO(
        //    int invoiceID, 
        //    string invoiceNumber, 
        //    int appointmentID, 
        //    int patientID, 
        //    decimal subTotal, 
        //    decimal discountAmount, 
        //    decimal? discountPercent, 
        //    enDiscountType? discountType, 
        //    int? discountAuthorizedByUserID, 
        //    decimal totalAmount, 
        //    decimal amountPaid, 
        //    decimal? outstandingBalance, 
        //    enInvoiceStatus status, 
        //    int? issuedByUserID, 
        //    DateTime? issuedAt, 
        //    int? voidedByUserID, 
        //    string voidReason, 
        //    string notes)
        //{
        //    InvoiceID = invoiceID;
        //    InvoiceNumber = invoiceNumber;
        //    AppointmentID = appointmentID;
        //    PatientID = patientID;
        //    SubTotal = subTotal;
        //    DiscountAmount = discountAmount;
        //    DiscountPercent = discountPercent;
        //    DiscountType = discountType;
        //    DiscountAuthorizedByUserID = discountAuthorizedByUserID;
        //    TotalAmount = totalAmount;
        //    AmountPaid = amountPaid;
        //    OutstandingBalance = outstandingBalance;
        //    Status = status;
        //    IssuedByUserID = issuedByUserID;
        //    IssuedAt = issuedAt;
        //    VoidedByUserID = voidedByUserID;
        //    VoidReason = voidReason;
        //    Notes = notes;
        //}
    }
}
