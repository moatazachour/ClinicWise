using ClinicWise.Business;
using ClinicWise.Contracts.Invoices;
using ClinicWise.Global_Classes;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClinicWise.Financial.Invoices.frmAddEditInvoice;

namespace ClinicWise.Financial.Invoices
{
    public partial class frmVoidingInvoice : Form
    {
        private int _InvoiceID;
        private clsInvoice _Invoice;

        public frmVoidingInvoice(int invoiceID)
        {
            InitializeComponent();
            _InvoiceID = invoiceID;
        }

        private async void frmVoidingInvoice_Load(object sender, System.EventArgs e)
        {
            InvoiceDTO invoiceDTO = await clsInvoice.FindAsync(_InvoiceID);

            if (invoiceDTO == null)
            {
                MessageBox.Show(
                    $"Invoice Does not exist!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                Close();
                return;
            }

            _Invoice = new clsInvoice(invoiceDTO);
            lblInvoiceNumber.Text = invoiceDTO.InvoiceNumber;
        }

        private void txtVoidReason_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVoidReason.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtVoidReason, "Field is empty!");
            }
            else
            {
                errorProvider1.SetError(txtNotes, null);
            }
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            _Invoice.Status = enInvoiceStatus.Void;
            _Invoice.VoidedByUserID = clsGlobalSettings.CurrentUserID;
            _Invoice.VoidedAt = DateTime.Now;
            _Invoice.VoidReason = txtVoidReason.Text;
            _Invoice.Notes = txtNotes.Text ?? null;

            if (_Invoice.Save())
            {
                MessageBox.Show(
                    "Invoice is now Voided!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
                await _OpenReplacementInvoice();
            }
            else
            {
                MessageBox.Show(
                    "Invoice void failed!",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task _OpenReplacementInvoice()
        {
            InvoiceDTO replacementInvoice = await clsInvoice.GetReplacementInvoiceAsync(_Invoice.AppointmentID);
            frmAddEditInvoice frm = new frmAddEditInvoice(replacementInvoice.InvoiceID, enInvoiceLoadMode.ByInvoice);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
