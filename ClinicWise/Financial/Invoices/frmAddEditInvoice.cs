using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.InvoiceItems;
using ClinicWise.Contracts.Invoices;
using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Patients;
using ClinicWise.Financial.InvoiceItems;
using ClinicWise.Global_Classes;
using ClinicWise.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Invoices
{
    public partial class frmAddEditInvoice : Form
    {
        public enum enInvoiceLoadMode { ByAppointment, ByInvoice }
        private enInvoiceLoadMode _LoadMode;
        private bool _IsLoading = false;

        private int _AppointmentID;
        private int _InvoiceID;
        private clsInvoice _Invoice;
        private List<InvoiceItemDTO> _InvoiceItems;

        public frmAddEditInvoice(int id, enInvoiceLoadMode loadMode)
        {
            InitializeComponent();

            _LoadMode = loadMode;
            
            if (_LoadMode == enInvoiceLoadMode.ByAppointment)
            {
                _AppointmentID = id;
                return;
            }

            _InvoiceID = id;
        }

        private async void frmAddEditInvoice_Load(object sender, EventArgs e)
        {
            await _LoadInformations(_LoadMode);
        }

        private async Task _LoadInformations(enInvoiceLoadMode loadMode)
        {
            _IsLoading = true;

            InvoiceDTO invoice;

            if (_LoadMode == enInvoiceLoadMode.ByAppointment)
                invoice = await clsInvoice.FindDraftedByAppointmentIdAsync(_AppointmentID);
            else
                invoice = await clsInvoice.FindAsync(_InvoiceID);

            if (invoice == null)
                return;

            _Invoice = new clsInvoice(invoice);

            lblInvoiceNumber.Text = _Invoice.InvoiceNumber;
            lblAppointmentID.Text = _Invoice.AppointmentID.ToString();
            lblPatient.Text = await _GetPatientFullName();
            lblDoctor.Text = await _GetDoctorFullLabelName();
            lblSubTotal.Text = $"{_Invoice.SubTotal} TND";
            if (_Invoice.DiscountType != null)
            {
                cbDiscountType.Text = _GetDiscountType();
                gbDiscount.Enabled = cbDiscountType.Text.Equals("Loyality")
                || cbDiscountType.Text.Equals("Financial Hardship")
                || cbDiscountType.Text.Equals("Staff");

                if (_Invoice.DiscountType != enDiscountType.Waiver)
                {
                    if (_Invoice.DiscountAmount > 0m)
                    {
                        nudDiscountAmount.Value = _Invoice.DiscountAmount;
                        cbDiscountMethod.Text = "By Amount";
                        nudDiscountAmount.Enabled = true;
                    }
                    else
                    {
                        nudDiscountPercent.Value = _Invoice.DiscountPercent ?? 0;
                        cbDiscountMethod.Text = "By Percentage";
                        nudDiscountPercent.Enabled = true;
                    }
                }
            }
            else
            {
                cbDiscountType.Text = "None";
            }

            lblTotalAmount.Text = $"{_Invoice.TotalAmount} TND";
            await _LoadInvoiceItems();

            _IsLoading = false;
        }

        private string _GetDiscountType()
        {
            switch (_Invoice.DiscountType)
            {
                case enDiscountType.Loyality:
                    return "Loyality";
                
                case enDiscountType.FinancialHardship:
                    return "Financial Hardship";

                case enDiscountType.Staff:
                    return "Staff";

                case enDiscountType.Waiver:
                    return "Waiver";
                
                default:
                    return "Loyality";
            }
        }

        private enDiscountType _SetDiscountType(string discountTypeLabel)
        {
            switch (discountTypeLabel)
            {
                case "Loyality":
                    return enDiscountType.Loyality;

                case "Financial Hardship":
                    return enDiscountType.FinancialHardship;

                case "Staff":
                    return enDiscountType.Staff;

                case "Waiver":
                    return enDiscountType.Waiver;

                default:
                    return enDiscountType.Loyality;
            }
        }

        private async Task _LoadInvoiceItems()
        {
            _InvoiceItems = await clsInvoiceItem.GetAllByInvoiceAsync(_Invoice.InvoiceID);
            dgvInvoiceItems.DataSource = _InvoiceItems;

            dgvInvoiceItems.Columns["InvoiceID"].Visible = false;
            dgvInvoiceItems.Columns["VisitFeeID"].Visible = false;
        }

        private async Task _ReloadAfterInvoiceItemsChangedAsync()
        {
            if (_Invoice == null)
            {
                await _LoadInformations(_LoadMode);
                return;
            }

            enDiscountType? discountType = _Invoice.DiscountType;
            decimal discountAmount = _Invoice.DiscountAmount;
            decimal? discountPercent = _Invoice.DiscountPercent;
            int? authorizedByUserID = _Invoice.DiscountAuthorizedByUserID;
            string discountTypeText = cbDiscountType.Text;
            string discountMethodText = cbDiscountMethod.Text;

            await _LoadInformations(_LoadMode);

            _IsLoading = true;

            _Invoice.DiscountType = discountType;
            _Invoice.DiscountAmount = discountAmount;
            _Invoice.DiscountPercent = discountPercent;
            _Invoice.DiscountAuthorizedByUserID = authorizedByUserID;

            cbDiscountType.Text = string.IsNullOrWhiteSpace(discountTypeText) ? "None" : discountTypeText;
            cbDiscountMethod.Text = discountMethodText;

            gbDiscount.Enabled = cbDiscountType.Text.Equals("Loyality")
                || cbDiscountType.Text.Equals("Financial Hardship")
                || cbDiscountType.Text.Equals("Staff");

            nudDiscountAmount.Maximum = Math.Max(_Invoice.SubTotal, discountAmount);
            nudDiscountAmount.Enabled = cbDiscountMethod.Text.Equals("By Amount");
            nudDiscountPercent.Enabled = cbDiscountMethod.Text.Equals("By Percentage");

            nudDiscountAmount.Value = discountAmount;
            nudDiscountPercent.Value = discountPercent ?? 0m;

            if (discountType == enDiscountType.Waiver)
            {
                _Invoice.OutstandingBalance = 0m;
            }
            else if (cbDiscountMethod.Text.Equals("By Amount"))
            {
                _Invoice.TotalAmount = _GetNewTotalAfterDiscountByAmount(_Invoice.SubTotal, discountAmount);
            }
            else if (cbDiscountMethod.Text.Equals("By Percentage"))
            {
                _Invoice.TotalAmount = _GetNewTotalAfterDiscountByPercent(_Invoice.SubTotal, discountPercent ?? 0m);
            }
            else
            {
                _Invoice.TotalAmount = _Invoice.SubTotal;
            }

            lblTotalAmount.Text = $"{_Invoice.TotalAmount} TND";

            _IsLoading = false;
        }

        private async Task<string> _GetDoctorFullLabelName()
        {
            AppointmentDTO appointmentDTO = await clsAppointment.FindAsync(_Invoice.AppointmentID);
            DoctorDTO doctorDTO = await clsDoctor.FindAsync(appointmentDTO.DoctorID);
            clsSpecialization specialization = await clsSpecialization.FindAsync(doctorDTO.SpecializationID);
            string doctorFullName = doctorDTO.FullName;
            string specializationName = specialization.Name;

            return string.Format("{0} - {1}", doctorFullName, specializationName);
        }

        private async Task<string> _GetPatientFullName()
        {
            PatientDTO patientDTO = await clsPatient.FindAsync(_Invoice.PatientID);
            return patientDTO.FullName;
        }

        private void cbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsLoading)
                return;

            if (cbDiscountType.Text.Equals("None"))
            {
                gbDiscount.Enabled = false;
                _ResetDiscountFields();
            }

            if (cbDiscountType.Text.Equals("Loyality")
                || cbDiscountType.Text.Equals("Financial Hardship")
                || cbDiscountType.Text.Equals("Staff"))
            {
                gbDiscount.Enabled = true;
                _ResetDiscountFields();
                _Invoice.DiscountType = _SetDiscountType(cbDiscountType.Text);
                _Invoice.DiscountAuthorizedByUserID = clsGlobalSettings.CurrentUser.UserID;
                nudDiscountAmount.Maximum = _Invoice.SubTotal;
            }

            if (cbDiscountType.Text.Equals("Waiver"))
            {
                gbDiscount.Enabled = false;
                _ResetDiscountFields();
                _Invoice.Status = enInvoiceStatus.Waived;
                _Invoice.DiscountType = enDiscountType.Waiver;
                _Invoice.OutstandingBalance = 0m;
                _Invoice.IssuedByUserID = clsGlobalSettings.CurrentUserID;
            }
        }

        private void cbDiscountMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsLoading) return;

            _Invoice.DiscountPercent = null;
            _Invoice.DiscountAmount = 0;
            _Invoice.TotalAmount = _Invoice.SubTotal;
            lblTotalAmount.Text = $"{_Invoice.TotalAmount} TND";

            nudDiscountAmount.Value = 0;
            nudDiscountPercent.Value = 0;
            nudDiscountAmount.Enabled = cbDiscountMethod.SelectedItem.Equals("By Amount");
            nudDiscountPercent.Enabled = cbDiscountMethod.SelectedItem.Equals("By Percentage");
        }

        private void _ResetDiscountFields()
        {
            _Invoice.DiscountType = null;
            _Invoice.DiscountPercent = null;
            _Invoice.DiscountAmount = 0;
            _Invoice.DiscountAuthorizedByUserID = null;
            _Invoice.TotalAmount = _Invoice.SubTotal;
            lblTotalAmount.Text = $"{_Invoice.TotalAmount} TND";


            nudDiscountAmount.Value = 0;
            nudDiscountPercent.Value = 0;
        }

        private void nudDiscountPercent_ValueChanged(object sender, EventArgs e)
        {
            if (_IsLoading) return;

            decimal totalAfterDiscount = _GetNewTotalAfterDiscountByPercent(_Invoice.SubTotal, nudDiscountPercent.Value);
            _Invoice.DiscountPercent = nudDiscountPercent.Value;
            _Invoice.TotalAmount = totalAfterDiscount;
            lblTotalAmount.Text = $"{totalAfterDiscount} TND";
        }

        private decimal _GetNewTotalAfterDiscountByPercent(decimal subTotal, decimal percent)
        {
            return Math.Round(subTotal - (subTotal * percent / 100), 2);
        }

        private void nudDiscountAmount_ValueChanged(object sender, EventArgs e)
        {
            if (_IsLoading) return;

            decimal totalAfterDiscount = _GetNewTotalAfterDiscountByAmount(_Invoice.SubTotal, nudDiscountAmount.Value);
            _Invoice.DiscountAmount = nudDiscountAmount.Value;
            _Invoice.TotalAmount = totalAfterDiscount;
            lblTotalAmount.Text = $"{totalAfterDiscount} TND";
        }

        private decimal _GetNewTotalAfterDiscountByAmount(decimal subTotal, decimal amount)
        {
            if (amount > subTotal)
                return 0m;

            return subTotal -= amount;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckFields())
                return;

            if (_Invoice.Status == enInvoiceStatus.Draft)
            {
                _Invoice.Status = enInvoiceStatus.Issued;
                _Invoice.IssuedByUserID = clsGlobalSettings.CurrentUserID;
            }

            if (_Invoice.Status == enInvoiceStatus.Issued)
                _Invoice.OutstandingBalance = _Invoice.TotalAmount;

            if (_Invoice.Save())
            {
                MessageBox.Show(
                    $"Invoice Saved Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnSave.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Invoice Failed to be saved",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private bool _CheckFields()
        {
            errorProvider1.Clear();

            bool isValid = true;

            if (_Invoice.DiscountType == enDiscountType.Loyality ||
                _Invoice.DiscountType == enDiscountType.FinancialHardship ||
                _Invoice.DiscountType == enDiscountType.Staff)
            {
                if (cbDiscountMethod.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbDiscountMethod,
                        "You should select a discount method!");

                    isValid = false;
                }

                if (cbDiscountMethod.Text == "By Percentage" &&
                    _Invoice.DiscountPercent == 0m)
                {
                    errorProvider1.SetError(nudDiscountPercent,
                        "Discount percent cannot be 0.");

                    isValid = false;
                }

                if (cbDiscountMethod.Text == "By Amount" &&
                    _Invoice.DiscountAmount == 0m)
                {
                    errorProvider1.SetError(nudDiscountAmount,
                        "Discount amount cannot be 0.");

                    isValid = false;
                }
            }

            return isValid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnResetForm_Click(object sender, EventArgs e)
        {
            await _LoadInformations(_LoadMode);
        }

        private async void btnAddInvoiceItem_Click(object sender, EventArgs e)
        {
            frmAddEditInvoiceItem frm = new frmAddEditInvoiceItem(-1, _Invoice.InvoiceID);
            frm.ShowDialog();

            await _ReloadAfterInvoiceItemsChangedAsync();
        }

        private async void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditInvoiceItem frm = new frmAddEditInvoiceItem(-1, _Invoice.InvoiceID);
            frm.ShowDialog();

            await _ReloadAfterInvoiceItemsChangedAsync();
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int invoiceItemID = (int)dgvInvoiceItems.CurrentRow.Cells[0].Value;

            frmAddEditInvoiceItem frm = new frmAddEditInvoiceItem(invoiceItemID, _Invoice.InvoiceID);
            frm.ShowDialog();

            await _ReloadAfterInvoiceItemsChangedAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            int invoiceItemID = (int)dgvInvoiceItems.CurrentRow.Cells[0].Value;

            frmAddEditInvoiceItem frm = new frmAddEditInvoiceItem(invoiceItemID, _Invoice.InvoiceID);
            frm.ShowDialog();

            await _ReloadAfterInvoiceItemsChangedAsync();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int invoiceItemID = (int)dgvInvoiceItems.CurrentRow.Cells[0].Value;

            if (MessageBox.Show(
                $"Are you sure you want to delete this item with ID [{invoiceItemID}]",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information)
                == DialogResult.OK)
            {
                if (clsInvoiceItem.Delete(invoiceItemID))
                    await _ReloadAfterInvoiceItemsChangedAsync();
                
                else
                    MessageBox.Show(
                        "Delete is not deleted due to data connected to it.",
                        "Error",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);

            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int invoiceItemID = (int)dgvInvoiceItems.CurrentRow.Cells[0].Value;

            if (MessageBox.Show(
                $"Are you sure you want to delete this item with ID [{invoiceItemID}]",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information)
                == DialogResult.OK)
            {
                if (clsInvoiceItem.Delete(invoiceItemID))
                    await _ReloadAfterInvoiceItemsChangedAsync();

                else
                    MessageBox.Show(
                        "Delete is not deleted due to data connected to it.",
                        "Error",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);

            }
        }

        private async void btnCheckMedicalRecord_Click(object sender, EventArgs e)
        {
            MedicalRecordDTO medicalRecord = await clsMedicalRecord.FindByAppointmentIDAsync(_Invoice.AppointmentID);
            frmMedicalRecordDetails frm = new frmMedicalRecordDetails(medicalRecord.RecordID);
            frm.ShowDialog();
        }
    }
}
