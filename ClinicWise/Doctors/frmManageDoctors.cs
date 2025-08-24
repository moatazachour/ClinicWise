using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Global_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmManageDoctors : Form
    {
        private List<DoctorDisplayDTO> _DoctorList;

        private List<DoctorDisplayDTO> _DoctorFilter;

        public frmManageDoctors()
        {
            InitializeComponent();
        }

        private async Task _RefreshData()
        {
            cbManageDoctors.SelectedItem = "None";

            _DoctorList = await clsDoctor.GetAllDoctorsAsync();

            dgvManageDoctors.DataSource = _DoctorList;

            lblRecordCount.Text = dgvManageDoctors.RowCount.ToString();

            mtxtFilter.Visible = false;
        }

        private async void frmManageDoctors_Load(object sender, EventArgs e)
        {
            await _RefreshData();
        }

        private async void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor(-1);
            frm.ShowDialog();

            await _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor((int)dgvManageDoctors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            await _RefreshData();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int doctorID = (int)dgvManageDoctors.CurrentRow.Cells[0].Value;

            if (MessageBox.Show(
                $"Are you sure you want to delete the doctor with ID [{doctorID}]",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information)
                == DialogResult.OK)
            {
                if (clsDoctor.Delete(doctorID, clsGlobalSettings.CurrentUserID))
                {
                    MessageBox.Show(
                        $"Doctor with ID = [{doctorID}] is deleted successfully",
                        "Succcess");

                    await _RefreshData();
                }
                else
                {
                    MessageBox.Show(
                        "Doctor deletion failed",
                        "Error",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);
                }

            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoctorDetails frm = new frmDoctorDetails((int)dgvManageDoctors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cbManageDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = (cbManageDoctors.Text != "None");

            if (mtxtFilter.Visible)
            {
                mtxtFilter.Mask = "";
                mtxtFilter.Text = "";
                mtxtFilter.Focus();
            }

            if (cbManageDoctors.Text == "None")
                dgvManageDoctors.DataSource = _DoctorList;
        }

        private async void dgvManageDoctors_DoubleClick(object sender, EventArgs e)
        {
            frmDoctorDetails frm = new frmDoctorDetails((int)dgvManageDoctors.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _RefreshData();
        }

        private void mtxtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (cbManageDoctors.Text)
            {
                case "DoctorID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _DoctorFilter = _DoctorList;
                    else
                        _DoctorFilter = _DoctorList.Where(d => d.DoctorID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Fullname":
                    _DoctorFilter = _DoctorList.Where(d => d.FullName.ToLower().Contains(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Gender":
                    _DoctorFilter = _DoctorList.Where(d => d.GenderCaption.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Phone":
                    _DoctorFilter = _DoctorList.Where(d => d.Phone.StartsWith(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Email":
                    _DoctorFilter = _DoctorList.Where(d => d.Email.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Specialization":
                    _DoctorFilter = _DoctorList.Where(d => d.Specialization.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Address":
                    _DoctorFilter = _DoctorList.Where(d => d.Address.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                default:
                    _DoctorFilter = _DoctorList;
                    break;
            }

            dgvManageDoctors.DataSource = _DoctorFilter;
            lblRecordCount.Text = dgvManageDoctors.RowCount.ToString();
        }

        private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbManageDoctors.Text == "DoctorID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
