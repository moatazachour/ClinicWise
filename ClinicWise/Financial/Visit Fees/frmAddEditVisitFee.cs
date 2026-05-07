using ClinicWise.Business;
using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.VisitTypeFees;
using ClinicWise.Global_Classes;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Visit_Fees
{
    public partial class frmAddEditVisitFee : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private int _VisitFeeID;
        private clsVisitTypeFee _VisitTypeFee;

        public frmAddEditVisitFee(int visitFeeID)
        {
            _VisitFeeID = visitFeeID;

            _Mode = _VisitFeeID == -1 ? enMode.AddNew : enMode.Update;
            InitializeComponent();
        }

        private async void frmAddEditVisitFee_Load(object sender, EventArgs e)
        {
            _ResetInformations();

            if (_Mode == enMode.Update)
                await _LoadDataAsync();
        }

        private async Task _LoadDataAsync()
        {
            VisitTypeFeeDTO visitTypeDTO = await clsVisitTypeFee.FindAsync(_VisitFeeID);
            _VisitTypeFee = new clsVisitTypeFee(visitTypeDTO);

            if (visitTypeDTO != null)
            {
                lblVisitTypeFeeID.Text = _VisitTypeFee.ID.ToString();
                cmbVisitType.SelectedIndex = (int)_VisitTypeFee.VisitType - 1;
                nudBaseAmount.Value = _VisitTypeFee.BaseAmount;
                dtpEffectiveFrom.Value = _VisitTypeFee.EffectiveFrom;
                if (_VisitTypeFee.EffectiveTo != null)
                {
                    dtpEffectiveTo.Value = (DateTime)_VisitTypeFee.EffectiveTo;
                    chkEffectiveToIsDefined.Checked = true;
                }
            }
        }

        private void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Visit Fee";
                _VisitTypeFee = new clsVisitTypeFee();
            }

            else
            {
                lblMode.Text = "Update Visit Fee";
            }

            this.Text = lblMode.Text;
            lblVisitTypeFeeID.Text = "N/A";
            cmbVisitType.SelectedIndex = -1;
            dtpEffectiveFrom.Value = DateTime.Now;
            dtpEffectiveTo.Value = DateTime.Now;
            chkEffectiveToIsDefined.Checked = false;

        }

        private void chkEffectiveToIsDefined_CheckedChanged(object sender, EventArgs e)
        {
            dtpEffectiveTo.Enabled = chkEffectiveToIsDefined.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _VisitTypeFee.VisitType = _GetVisitTypeFromComboBox();
            _VisitTypeFee.BaseAmount = nudBaseAmount.Value;
            _VisitTypeFee.EffectiveFrom = dtpEffectiveFrom.Value;
            _VisitTypeFee.EffectiveTo = chkEffectiveToIsDefined.Checked ? (DateTime?)dtpEffectiveTo.Value : null;
            _VisitTypeFee.CreatedByUserID = clsGlobalSettings.CurrentUserID;

            if (_VisitTypeFee.Save())
            {
                MessageBox.Show(
                    $"Visit Type Fee Saved Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _Mode = enMode.Update;
                btnSave.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                   "Visit Type Fee saving failed!",
                   "Failure",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }

        }

        private enVisitType _GetVisitTypeFromComboBox()
        {
            switch (cmbVisitType.Text)
            {
                case "Consultation":
                    return enVisitType.Consultation;

                case "Follow up":
                    return enVisitType.FollowUp;

                case "Emergency":
                    return enVisitType.Emergency;

                case "Routine Check":
                    return enVisitType.RoutineCheck;

                case "Vaccination":
                    return enVisitType.Vaccination;

                case "Lab Test":
                    return enVisitType.LabTest;

                default:
                    return enVisitType.Consultation;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
