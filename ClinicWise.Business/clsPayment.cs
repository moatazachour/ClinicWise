using ClinicWise.Contracts.Invoices;
using ClinicWise.Contracts.Payments;
using ClinicWise.DataAccess;
using System;

namespace ClinicWise.Business
{
    public class clsPayment
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;

        public int PaymentID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime PaymentDate { get; set; }
        public enPaymentMethod Method { get; set; }
        public decimal AmountPaid { get; set; }
        public int RecordedByUserID { get; set; }

        public clsPayment()
        {
            PaymentID = -1;
            InvoiceID = -1;
            PaymentDate = DateTime.Now;
            Method = enPaymentMethod.Cash;
            AmountPaid = 0;
            RecordedByUserID = -1;

            Mode = enMode.AddNew;
        }

        public clsPayment(
            int paymentID, 
            int invoiceID, 
            DateTime paymentDate, 
            enPaymentMethod paymentMethod, 
            decimal amountPaid,
            int recordedByUserID)
        {
            PaymentID = paymentID;
            InvoiceID = invoiceID;
            PaymentDate = paymentDate;
            Method = paymentMethod;
            AmountPaid = amountPaid;
            RecordedByUserID = recordedByUserID;

            Mode = enMode.Update;
        }
    
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }

        private bool _Update()
        {
            return clsPaymentData.Update(PaymentID, PaymentDate, Method,  AmountPaid, RecordedByUserID);
        }

        private bool _AddNew()
        {
            PaymentID = clsPaymentData.AddNew(InvoiceID, PaymentDate, Method, AmountPaid, RecordedByUserID);
            return PaymentID != -1;
        }
    }
}
