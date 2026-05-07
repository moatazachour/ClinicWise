using ClinicWise.Business;
using ClinicWise.Contracts.VisitTypeFees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Visit_Fees
{
    public partial class frmManageVisitFees : Form
    {
        private List<VisitTypeFeeViewDTO> _VisitTypesFeeList;
        private List<VisitTypeFeeViewDTO> _VisitTypesFeeFilter;

        public frmManageVisitFees()
        {
            InitializeComponent();
        }

        private async void btnAddVisitFee_Click(object sender, EventArgs e)
        {
            frmAddEditVisitFee frm = new frmAddEditVisitFee();
            frm.ShowDialog();

            await _LoadDataAsync();
        }

        private async void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditVisitFee frm = new frmAddEditVisitFee();
            frm.ShowDialog();

            await _LoadDataAsync();
        }

        private async void frmManageVisitFees_Load(object sender, EventArgs e)
        {
            await _LoadDataAsync();
        }

        private async Task _LoadDataAsync()
        {
            cbManageVisitFees.SelectedItem = "None";
            _VisitTypesFeeList = await clsVisitTypeFee.GetAllAsync();
            dgvManageVisitTypesFees.DataSource = _VisitTypesFeeList;

        }

        private void cbManageVisitFees_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVisitTypes.Visible = cbManageVisitFees.SelectedItem.Equals("Visit Type");
            cbStatus.Visible = cbManageVisitFees.SelectedItem.Equals("Status");

            if (cbManageVisitFees.SelectedItem.Equals("None"))
                dgvManageVisitTypesFees.DataSource = _VisitTypesFeeList;

            lblRecordCount.Text = dgvManageVisitTypesFees.RowCount.ToString();
        }

        private void cbVisitTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbVisitTypes.Text)
            {
                case "Consultation":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => vf.VisitTypeLabel == "Consultation").ToList();
                    break;

                case "Follow up":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => vf.VisitTypeLabel == "Follow Up").ToList();
                    break;

                case "Emergency":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => vf.VisitTypeLabel == "Emergency").ToList();
                    break;

                case "Routine Check":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => vf.VisitTypeLabel == "Routine Check").ToList();
                    break;

                case "Vaccination":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => vf.VisitTypeLabel == "Vaccination").ToList();
                    break;

                case "Lab Test":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => vf.VisitTypeLabel == "Lab Test").ToList();
                    break;

                default:
                    _VisitTypesFeeFilter = _VisitTypesFeeList;
                    break;
            }

            dgvManageVisitTypesFees.DataSource = _VisitTypesFeeFilter;
            lblRecordCount.Text = dgvManageVisitTypesFees.RowCount.ToString();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbStatus.Text)
            {
                case "All":
                    _VisitTypesFeeFilter = _VisitTypesFeeList;
                    break;

                case "Active":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => vf.IsActive).ToList();
                    break;

                case "InActive":
                    _VisitTypesFeeFilter = _VisitTypesFeeList.Where(vf => !vf.IsActive).ToList();
                    break;

                default:
                    _VisitTypesFeeFilter = _VisitTypesFeeList;
                    break;
            }

            dgvManageVisitTypesFees.DataSource = _VisitTypesFeeFilter;
            lblRecordCount.Text = dgvManageVisitTypesFees.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
