using ClinicWise.Business.Services;
using ClinicWise.Contracts.Guardians;
using ClinicWise.Contracts.Invoices;
using ClinicWise.Contracts.Patients;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using static ClinicWise.Business.InvoiceReminderRecipientInformations;

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
        public DateTime? VoidedAt { get; set; }
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
            VoidedAt = null;
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
            DateTime? voidedAt,
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
            VoidedAt = voidedAt;
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
            VoidedAt = invoiceDTO.VoidedAt;
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

        public static async Task<InvoiceDTO> FindAsync(int invoiceID)
        {
            return await clsInvoiceData.GetByIDAsync(invoiceID);
        }

        public bool Save()
        {
            return _Update();
        }

        private bool _Update()
        {
            return clsInvoiceData.Update(InvoiceID, SubTotal, DiscountAmount, DiscountPercent, DiscountType, DiscountAuthorizedByUserID,
                TotalAmount, AmountPaid, OutstandingBalance, Status, IssuedByUserID, IssuedAt, VoidedByUserID, VoidedAt, VoidReason, Notes);
        }

        public static async Task<InvoiceDTO> GetReplacementInvoiceAsync(int appointmentID)
        {
            return await clsInvoiceData.GetLatestInvoiceByAppointmentIdAsync(appointmentID);
        }

        public static async Task<InvoiceDTO> FindByInvoiceNumberAsync(string invoiceNumber)
        {
            return await clsInvoiceData.GetByInvoiceNumberAsync(invoiceNumber);
        }

        public static void ProcessInvoiceReminders(byte invoiceReminderMaxCount, byte invoiceReminderIntervalDays)
        {
            List<InvoicesDueForReminderDTO> invoiceDueForReminder = clsInvoiceData.GetDueForReminder(invoiceReminderMaxCount, invoiceReminderIntervalDays);
            InvoiceReminderRecipientInformations recipientInfo;

            foreach (var invoice in invoiceDueForReminder)
            {
                if (invoice.RemindersSentCount >= invoiceReminderMaxCount)
                {
                    _MarkInvoiceAsOverdue(invoice);
                    continue;
                }
                recipientInfo = _GetRecipientInfos(invoice.PatientID);

                if (recipientInfo == null || string.IsNullOrWhiteSpace(recipientInfo.Email))
                {
                    clsGlobal.LogWarning($"The is no email to send to for the patient with ID = {invoice.PatientID}");
                    continue;
                }
                _SendAndLogInvoiceReminder(invoice, recipientInfo);
            }
        }

        private static void _MarkInvoiceAsOverdue(InvoicesDueForReminderDTO invoice)
        {
            if (!clsInvoiceData.MarkOverdue(invoice.InvoiceID))
                clsGlobal.LogWarning("Invoice Overdue Marking Failed!");

            InvoiceReminderRecipientInformations recipientInfo = _GetRecipientInfos(invoice.PatientID);
            if (recipientInfo == null || string.IsNullOrWhiteSpace(recipientInfo.Email))
            {
                clsGlobal.LogWarning($"The is no email to send to for the patient with ID = {invoice.PatientID}");
                return;
            }

            _SendFinalNotice(invoice, recipientInfo);
        }

        private static void _SendFinalNotice(
            InvoicesDueForReminderDTO invoice, 
            InvoiceReminderRecipientInformations recipientInfo)
        {
            string to;
            string subject;
            string body;

            to = recipientInfo.Email;
            subject = $"Final Notice – Invoice {invoice.InvoiceNumber} Now Overdue";
            body = _GetFinalNoticeEmailBody(recipientInfo, invoice);

            EmailService.SendEmail(to, subject, body);
        }

        private static string _GetFinalNoticeEmailBody(
            InvoiceReminderRecipientInformations recipientInfo, 
            InvoicesDueForReminderDTO invoice)
        {
            if (recipientInfo.RecipientType == enRecipientType.Patient)
                return $@"Dear {recipientInfo.PatientName},

Despite our previous reminders, the outstanding balance of 
{invoice.OutstandingBalance:C} on invoice {invoice.InvoiceNumber}, 
issued on {invoice.IssuedAt:MMMM dd, yyyy}, remains unpaid.

Your invoice has now been marked as overdue. We strongly urge 
you to contact us as soon as possible to settle this balance 
and avoid any further action.

Warm regards,
ClinicWise Team";

            return $@"Dear {recipientInfo.GuardianName},

Despite our previous reminders, the outstanding balance of 
{invoice.OutstandingBalance:C} on invoice {invoice.InvoiceNumber} 
for your dependent {recipientInfo.PatientName}, issued on 
{invoice.IssuedAt:MMMM dd, yyyy}, remains unpaid.

This invoice has now been marked as overdue. We strongly urge 
you to contact us as soon as possible to settle this balance 
and avoid any further action.

Warm regards,
ClinicWise Team";
        }

        private static InvoiceReminderRecipientInformations _GetRecipientInfos(int patientID)
        {
            InvoiceReminderRecipientInformations recipientInfo = new InvoiceReminderRecipientInformations();

            PatientDTO patientDTO = clsPatient.Find(patientID);
            if (patientDTO == null)
                return null;

            clsPatient patient = new clsPatient(patientDTO);

            recipientInfo.PatientName = patient.FullName;

            if (patient.IsAdult)
            {
                recipientInfo.Email = patient.Email;
                recipientInfo.RecipientType = enRecipientType.Patient;
            }
            else
            {
                if (patient.GuardianID.HasValue)
                {
                    GuardianDTO guardianDTO = clsGuardian.Find(patient.GuardianID.Value);

                    recipientInfo.Email = guardianDTO.Email;
                    recipientInfo.RecipientType = enRecipientType.Guardian;
                    recipientInfo.PatientName = patient.FullName;
                    recipientInfo.GuardianName = guardianDTO.FullName;
                }
                else
                {
                    recipientInfo = null;
                }
            }

            return recipientInfo;
        }

        private static void _SendAndLogInvoiceReminder(
            InvoicesDueForReminderDTO invoice,
            InvoiceReminderRecipientInformations recipientInfo)
        {
            string to;
            string subject;
            string body;

            to = recipientInfo.Email;
            subject = $"Payment Reminder – Outstanding Balance on Invoice {invoice.InvoiceNumber}";
            body = _GetInvoiceReminderEmailBody(recipientInfo, invoice);
            
            EmailService.SendEmail(to, subject, body);

            if (!clsInvoiceReminder.AddNew(
                invoice.InvoiceID,
                (byte)(invoice.RemindersSentCount + 1), 
                recipientInfo.Email, 
                DateTime.Now))
            {
                clsGlobal.LogWarning("The reminder persistance failed!");
            }
        }

        private static string _GetInvoiceReminderEmailBody(InvoiceReminderRecipientInformations recipientInfo, InvoicesDueForReminderDTO invoice)
        {
            if (recipientInfo.RecipientType == enRecipientType.Patient)
                return $@"Dear {recipientInfo.PatientName},

This is a friendly reminder that you have an outstanding balance 
of {invoice.OutstandingBalance:C} on invoice {invoice.InvoiceNumber}, 
issued on {invoice.IssuedAt:MMMM dd, yyyy}.

Please contact us at your earliest convenience to arrange payment.

Warm regards,
ClinicWise Team";
            
            return $@"Dear {recipientInfo.GuardianName},

This is a friendly reminder that your dependent {recipientInfo.PatientName} 
has an outstanding balance of {invoice.OutstandingBalance:C} on invoice 
{invoice.InvoiceNumber}, issued on {invoice.IssuedAt:MMMM dd, yyyy}.

Please contact us at your earliest convenience to arrange payment.

Warm regards,
ClinicWise Team";
        }
    }

    internal class InvoiceReminderRecipientInformations
    {
        public enum enRecipientType { Patient, Guardian }

        public string PatientName { get; set; }
        public string GuardianName { get; set; }
        public string Email { get; set; }
        public enRecipientType RecipientType { get; set; }
    }
}
