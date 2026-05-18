using ClinicWise.Business;
using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.Payments;
using ClinicWise.Global_Classes;
using System;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ClinicWise.Financial.Payments
{
    public partial class frmAddEditPayment : Form
    {
        private int _PaymentID;

        private clsInvoice _SelectedInvoice;

        public clsInvoice SelectedInvoice
        {
            get
            {
                return ctrlInvoiceCardWithFilter1.SelectedInvoice;
            }
            set
            {
                _SelectedInvoice = value;
            }
        }

        private clsPayment _Payment;
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public frmAddEditPayment(int paymentID)
        {
            InitializeComponent();

            _PaymentID = paymentID;
            _Mode = _PaymentID == -1 ? enMode.AddNew : enMode.Update;
        }

        public async Task LoadInvoice(int invoiceID)
        {
            await ctrlInvoiceCardWithFilter1.LoadAsync(invoiceID);
            SelectedInvoice = ctrlInvoiceCardWithFilter1.SelectedInvoice;
        }

        private void frmAddEditPayment_Load(object sender, System.EventArgs e)
        {
            _ResetInformations();
        }

        private void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add Payment";
                lblMode.Text = "Add Payment";
                _Payment = new clsPayment();
            }
            else
            {
                this.Text = "Update Payment";
                lblMode.Text = "Update Payment";
            }

            cbPaymentMethod.SelectedIndex = -1;
            nudAmountPaid.Value = 0m;
        }

        private void cbPaymentMethod_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbPaymentMethod.SelectedItem == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbPaymentMethod , "Choose Payment Method!");
            }
            else
            {
                errorProvider1.SetError(cbPaymentMethod, null);
            }
        }

        private void nudAmountPaid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nudAmountPaid.Value == 0m)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudAmountPaid, "Amount should not be 0!");
            }
            else
            {
                errorProvider1.SetError(cbPaymentMethod, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (SelectedInvoice == null)
            {
                MessageBox.Show("Select an invoice to pay!", "Invoice Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Payment.InvoiceID = SelectedInvoice.InvoiceID;
            _Payment.PaymentDate = DateTime.Now;
            _Payment.Method = _GetPaymentMethod();
            _Payment.AmountPaid = nudAmountPaid.Value;
            _Payment.RecordedByUserID = clsGlobalSettings.CurrentUserID;

            if (_Payment.Save())
            {
                MessageBox.Show(
                    $"Payment Saved Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnSave.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Payment Failed to be saved",
                    "Failed",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private enPaymentMethod _GetPaymentMethod()
        {
            switch (cbPaymentMethod.Text)
            {
                case "Cash":
                    return enPaymentMethod.Cash;
                
                case "Card":
                    return enPaymentMethod.Card;
                
                case "Bank Transfer":
                    return enPaymentMethod.BankTransfer;

                case "Insurance":
                    return enPaymentMethod.Insurance;

                default:
                    return enPaymentMethod.Insurance;
            }
        }
    }
}
