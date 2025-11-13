using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Doctors;
using ClinicWise.Contracts.Patients;
using ClinicWise.Contracts.Speciatizations;
using ClinicWise.Doctors;
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
    public partial class frmPatientPicker : Form
    {
        public frmPatientPicker()
        {
            InitializeComponent();
        }

        public delegate void DataBackEventHandler(int patientID);

        public event DataBackEventHandler DataBack;


        private List<PatientDisplayDTO> _PatientList;

        private List<PatientDisplayDTO> _PatientFilter;

        private async Task _LoadData()
        {
            cbManagePatients.SelectedItem = "None";

            _PatientList = await clsPatient.GetAllAsync();

            dgvManagePatients.DataSource = _PatientList;

            mtxtFilter.Visible = false;
        }

        private async void frmPatientPicker_Load(object sender, EventArgs e)
        {
            await _LoadData();
        }

        private void frmPatientPicker_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        private async void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient(-1);

            frm.ShowDialog();

            await _LoadData();
        }

        private void pickPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pickedPatientID = (int)dgvManagePatients.CurrentRow.Cells[0].Value;

            DataBack?.Invoke(pickedPatientID);

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int patientID = (int)dgvManagePatients.CurrentRow.Cells[0].Value;

            frmPatientDetails frm = new frmPatientDetails((int)dgvManagePatients.CurrentRow.Cells[0].Value);
            
            frm.ShowDialog();
        }
    }
}
