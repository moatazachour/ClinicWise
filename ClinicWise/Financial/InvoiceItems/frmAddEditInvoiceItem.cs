using ClinicWise.Business;
using ClinicWise.Contracts.InvoiceItems;
using ClinicWise.Contracts.Invoices;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.InvoiceItems
{
    public partial class frmAddEditInvoiceItem : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private int _InvoiceItemID;
        private int _InvoiceID;
        private InvoiceDTO _Invoice;
        private clsInvoiceItem _InvoiceItem;
        private decimal _TotalAmount = 0m;

        public frmAddEditInvoiceItem(int invoiceItemId, int invoiceID)
        {
            InitializeComponent();

            _InvoiceItemID = invoiceItemId;
            _InvoiceID = invoiceID;
            _Mode = _InvoiceItemID == -1 ? enMode.AddNew : enMode.Update;
        }

        private async void frmAddEditInvoiceItem_Load(object sender, EventArgs e)
        {
            await _ResetInformations();

            if (_Mode == enMode.Update)
                await _LoadDataAsync();
        }

        private async Task _LoadDataAsync()
        {
            InvoiceItemDTO invoiceItemDTO = await clsInvoiceItem.FindAsync(_InvoiceItemID);

            if (invoiceItemDTO == null)
            {
                MessageBox.Show(
                    "Invoice Item Not Found!",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

                return;
            }

            _InvoiceItem = new clsInvoiceItem(invoiceItemDTO);
            lblItemID.Text = _InvoiceItem.ItemID.ToString();
            lblInvoiceNumber.Text = _Invoice.InvoiceNumber;
            txtDescription.Text = _InvoiceItem.Description;
            nudQuantity.Value = _InvoiceItem.Quantity;
            nudUnitPrice.Value = _InvoiceItem.UnitPrice;
            lblTotalPrice.Text = $"{_InvoiceItem.TotalPrice} DNT";
        }

        private async Task _ResetInformations()
        {
            _Invoice = await clsInvoice.FindAsync(_InvoiceID);

            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Invoice Item";
                lblMode.Text = "Add New Invoice Item";
                _InvoiceItem = new clsInvoiceItem();
            }
            else
            {
                this.Text = "Update Invoice Item";
                lblMode.Text = "Update Invoice Item";
            }

            lblInvoiceNumber.Text = _Invoice.InvoiceNumber;
            txtDescription.Text = string.Empty;
            nudQuantity.Value = 1m;
            nudUnitPrice.Value = 0m;
            lblTotalPrice.Text = "0 DNT";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _InvoiceItem.InvoiceID = _InvoiceID;
            _InvoiceItem.Description = txtDescription.Text;
            _InvoiceItem.Quantity = Convert.ToInt32(nudQuantity.Value);
            _InvoiceItem.UnitPrice = nudUnitPrice.Value;
            _InvoiceItem.TotalPrice = _TotalAmount;

            if (_InvoiceItem.Save())
            {
                MessageBox.Show(
                    $"Invoice Item Saved Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnSave.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Invoice Item Failed to be saved",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Field is empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void nudUnitPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nudUnitPrice.Value <= 0m)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudUnitPrice, "Price is inacurate!");
            }
            else
            {
                errorProvider1.SetError(nudUnitPrice, null);
            }
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            _TotalAmount = nudQuantity.Value * nudUnitPrice.Value;
            lblTotalPrice.Text = $"{_TotalAmount} DNT";
        }

        private void nudUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            _TotalAmount = nudQuantity.Value * nudUnitPrice.Value;
            lblTotalPrice.Text = $"{_TotalAmount} DNT";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
