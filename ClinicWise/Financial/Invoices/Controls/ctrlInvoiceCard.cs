using ClinicWise.Business;
using ClinicWise.Contracts.Invoices;
using ClinicWise.Contracts.Patients;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Invoices.Controls
{
    public partial class ctrlInvoiceCard : UserControl
    {
        public clsInvoice SelectedInvoice;

        public ctrlInvoiceCard()
        {
            InitializeComponent();
        }

        public async Task LoadInformations(int invoiceID)
        {
            InvoiceDTO invoiceDTO = await clsInvoice.FindAsync(invoiceID);

            if (invoiceDTO == null)
            {
                MessageBox.Show("Invoice does not exist", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblInvoiceID.Text = invoiceDTO.InvoiceID.ToString();
            lblAppointmentID.Text = invoiceDTO.AppointmentID.ToString();
            lblInvoiceNumber.Text = invoiceDTO.InvoiceNumber;
            lblPatient.Text = await _GetPatientFullName(invoiceDTO.PatientID);
            lblStatus.Text = _GetStatusName(invoiceDTO.Status);
            lblSubTotal.Text = $"{invoiceDTO.SubTotal} DNT";
            lblTotalAmount.Text = $"{invoiceDTO.TotalAmount} DNT";
            lblAmountPaid.Text = $"{invoiceDTO.AmountPaid} DNT";
            lblOutstandingAmount.Text = $"{invoiceDTO.OutstandingBalance} DNT";

            SelectedInvoice = new clsInvoice(invoiceDTO);
        }

        public async Task LoadInformationsByInvoiceNumber(string invoiceNumber)
        {
            InvoiceDTO invoiceDTO = await clsInvoice.FindByInvoiceNumberAsync(invoiceNumber);

            if (invoiceDTO == null)
            {
                MessageBox.Show("Invoice does not exist", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblInvoiceID.Text = invoiceDTO.InvoiceID.ToString();
            lblAppointmentID.Text = invoiceDTO.AppointmentID.ToString();
            lblInvoiceNumber.Text = invoiceDTO.InvoiceNumber;
            lblPatient.Text = await _GetPatientFullName(invoiceDTO.PatientID);
            lblStatus.Text = _GetStatusName(invoiceDTO.Status);
            lblSubTotal.Text = $"{invoiceDTO.SubTotal} DNT";
            lblTotalAmount.Text = $"{invoiceDTO.TotalAmount} DNT";
            lblAmountPaid.Text = $"{invoiceDTO.AmountPaid} DNT";
            lblOutstandingAmount.Text = $"{invoiceDTO.OutstandingBalance} DNT";

            SelectedInvoice = new clsInvoice(invoiceDTO);
        }


        private string _GetStatusName(enInvoiceStatus status)
        {
            switch (status)
            {
                case enInvoiceStatus.Draft:
                    return "Draft";
                case enInvoiceStatus.Issued:
                    return "Issued";
                case enInvoiceStatus.PartiallyPaid:
                    return "Partially Paid";
                case enInvoiceStatus.Paid:
                    return "Paid";
                case enInvoiceStatus.Waived:
                    return "Waived";
                case enInvoiceStatus.Void:
                    return "Void";
                default:
                    return "Indefined";
            }
        }

        private async Task<string> _GetPatientFullName(int patientID)
        {
            PatientDTO patient = await clsPatient.FindAsync(patientID);
            return patient.FullName;
        }
    }
}
