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
        private int _VisitFeeID;
        private clsVisitTypeFee _VisitTypeFee;

        public frmAddEditVisitFee()
        {
            InitializeComponent();
        }

        private async void frmAddEditVisitFee_Load(object sender, EventArgs e)
        {
            _ResetInformations();
        }

        private void _ResetInformations()
        {
            lblMode.Text = "Add New Visit Fee";
            _VisitTypeFee = new clsVisitTypeFee();
            this.Text = lblMode.Text;
            lblVisitTypeFeeID.Text = "N/A";
            cmbVisitType.SelectedIndex = -1;
            dtpEffectiveFrom.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _VisitTypeFee.VisitType = _GetVisitTypeFromComboBox();
            _VisitTypeFee.BaseAmount = nudBaseAmount.Value;
            _VisitTypeFee.EffectiveFrom = dtpEffectiveFrom.Value;
            _VisitTypeFee.EffectiveTo = null;
            _VisitTypeFee.CreatedByUserID = clsGlobalSettings.CurrentUserID;


            if (_VisitTypeFee.Save())
            {
                MessageBox.Show(
                    $"Visit Type Fee Saved Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

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
