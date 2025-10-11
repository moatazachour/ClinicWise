using ClinicWise.Business;
using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Patients
{
    public partial class frmManagePatients : Form
    {
        private List<PatientDisplayDTO> _PatientList;

        private List<PatientDisplayDTO> _PatientFilter;

        public frmManagePatients()
        {
            InitializeComponent();
        }

        private async Task _RefreshData()
        {
            cbManagePatients.SelectedItem = "None";
            _PatientList = await clsPatient.GetAllAsync();
            dgvManagePatients.DataSource = _PatientList;

            lblRecordCount.Text = dgvManagePatients.RowCount.ToString();

            mtxtFilter.Visible = false;

        }

        private async void frmManagePatients_Load(object sender, EventArgs e)
        {
            await _RefreshData();
        }

        private async void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient(-1);

            frm.ShowDialog();

            await _RefreshData();
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient(-1);

            frm.ShowDialog();

            await _RefreshData();
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient((int)dgvManagePatients.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _RefreshData();
        }

        private void mtxtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (cbManagePatients.Text)
            {
                case "PatientID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _PatientFilter = _PatientList;
                    else
                        _PatientFilter = _PatientList.Where(p => p.PatientID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Fullname":
                    _PatientFilter = _PatientList.Where(p => p.FullName.ToLower().Contains(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Gender":
                    _PatientFilter = _PatientList.Where(p => p.GenderCaption.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Phone":
                    _PatientFilter = _PatientList.Where(p => p.Phone.StartsWith(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Email":
                    _PatientFilter = _PatientList.Where(p => p.Email.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Address":
                    _PatientFilter = _PatientList.Where(p => p.Address != null &&
                                                             p.Address.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                default:
                    _PatientFilter = _PatientList;
                    break;
            }

            dgvManagePatients.DataSource = _PatientFilter;
            lblRecordCount.Text = dgvManagePatients.RowCount.ToString();
        }

        private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbManagePatients.Text == "PatientID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbManagePatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = (cbManagePatients.Text != "None");

            if (mtxtFilter.Visible)
            {
                mtxtFilter.Mask = "";
                mtxtFilter.Text = "";
                mtxtFilter.Focus();
            }

            if (cbManagePatients.Text == "None")
                dgvManagePatients.DataSource = _PatientList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
