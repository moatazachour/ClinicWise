using ClinicWise.Contracts.Invoices;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsInvoice
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;

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

        public clsInvoice()
        {
            InvoiceID = -1;
            InvoiceNumber = null;
            AppointmentID = -1;
            PatientID = -1;
            SubTotal = 0;
            DiscountAmount = 0;
            DiscountPercent = null;
            DiscountType = null;
            DiscountAuthorizedByUserID = null;
            TotalAmount = 0;
            AmountPaid = 0;
            OutstandingBalance = null;
            Status = enInvoiceStatus.Draft;
            IssuedByUserID = null;
            IssuedAt = null;
            VoidedByUserID = null;
            VoidReason = null;
            Notes = null;

            Mode = enMode.Update;
        }

        public clsInvoice(
            int invoiceID, 
            string invoiceNumber, 
            int appointmentID, 
            int patientID, 
            decimal subTotal, 
            decimal discountAmount, 
            decimal? discountPercent, 
            enDiscountType? discountType, 
            int? discountAuthorizedByUserID, 
            decimal totalAmount, 
            decimal amountPaid, 
            decimal? outstandingBalance, 
            enInvoiceStatus status, 
            int? issuedByUserID, 
            DateTime? issuedAt, 
            int? voidedByUserID, 
            string voidReason, 
            string notes)
        {
            InvoiceID = invoiceID;
            InvoiceNumber = invoiceNumber;
            AppointmentID = appointmentID;
            PatientID = patientID;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            DiscountPercent = discountPercent;
            DiscountType = discountType;
            DiscountAuthorizedByUserID = discountAuthorizedByUserID;
            TotalAmount = totalAmount;
            AmountPaid = amountPaid;
            OutstandingBalance = outstandingBalance;
            Status = status;
            IssuedByUserID = issuedByUserID;
            IssuedAt = issuedAt;
            VoidedByUserID = voidedByUserID;
            VoidReason = voidReason;
            Notes = notes;

            Mode = enMode.Update;
        }

        public clsInvoice(InvoiceDTO invoiceDTO)
        {
            InvoiceID = invoiceDTO.InvoiceID;
            InvoiceNumber = invoiceDTO.InvoiceNumber;
            AppointmentID = invoiceDTO.AppointmentID;
            PatientID = invoiceDTO.PatientID;
            SubTotal = invoiceDTO.SubTotal;
            DiscountAmount = invoiceDTO.DiscountAmount;
            DiscountPercent = invoiceDTO.DiscountPercent;
            DiscountType = invoiceDTO.DiscountType;
            DiscountAuthorizedByUserID = invoiceDTO.DiscountAuthorizedByUserID;
            TotalAmount = invoiceDTO.TotalAmount;
            AmountPaid = invoiceDTO.AmountPaid;
            OutstandingBalance = invoiceDTO.OutstandingBalance;
            Status = invoiceDTO.Status;
            IssuedByUserID = invoiceDTO.IssuedByUserID;
            IssuedAt = invoiceDTO.IssuedAt;
            VoidedByUserID = invoiceDTO.VoidedByUserID;
            VoidReason = invoiceDTO.VoidReason;
            Notes = invoiceDTO.Notes;

            Mode = enMode.Update;
        }

        public static async Task<InvoiceDTO> FindDraftedByAppointmentIdAsync(int appointmentID)
        {
            return await clsInvoiceData.GetByAppointmentIdAndStatusAsync(appointmentID, (byte)enInvoiceStatus.Draft);
        }

        public static async Task<List<InvoiceViewDTO>> GetAllAsync()
        {
            return await clsInvoiceData.GetAllAsync();
        }
    }
}
