using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.InvoiceItems;
using ClinicWise.Contracts.Invoices;
using ClinicWise.Contracts.Patients;
using ClinicWise.Global_Classes;
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

                if (_Invoice.DiscountType != enDiscountType.Waiver)
                {
                    if (_Invoice.DiscountAmount > 0m)
                    {
                        nudDiscountAmount.Value = _Invoice.DiscountAmount;
                        cbDiscountMethod.Text = "By Amount";
                    }
                    else
                    {
                        nudDiscountPercent.Value = _Invoice.DiscountPercent ?? 0;
                        cbDiscountMethod.Text = "By Percentage";
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
    }
}
