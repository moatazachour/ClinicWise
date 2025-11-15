using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Doctors;
using ClinicWise.Contracts.Speciatizations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmDoctorPicker : Form
    {
        public frmDoctorPicker()
        {
            InitializeComponent();
        }

        public delegate void DataBackEventHandler(int doctorID);

        public event DataBackEventHandler DataBack;


        private List<DoctorDisplayPickerDTO> _DoctorList;

        private List<DoctorDisplayPickerDTO> _DoctorFilter;

        private async Task<List<DoctorDisplayPickerDTO>> _GetDoctorsList()
        {
            List<DoctorDisplayDTO> doctors = await clsDoctor.GetAllDoctorsAsync();

            return doctors.Select(d => new DoctorDisplayPickerDTO
            {
                DoctorID = d.DoctorID,
                FullName = d.FullName,
                Specialization = d.Specialization
            }).ToList();
        }

        private async Task _LoadSpecializations()
        {
            List<SpecializationDTO> specializations = await clsSpecialization.GetAllAsync();

            cbDoctorSpecialization.Items.Add("All");

            foreach (SpecializationDTO specialization in specializations)
            {
                cbDoctorSpecialization.Items.Add(specialization.Name);
            }
        }

        private async Task _LoadData()
        {
            await _LoadSpecializations();

            cbManageDoctors.SelectedItem = "Specialization";
            cbDoctorSpecialization.SelectedItem = "All";

            _DoctorList = await _GetDoctorsList();

            dgvManageDoctors.DataSource = _DoctorList;

            mtxtFilter.Visible = false;
        }

        private async void frmDoctorPicker_Load(object sender, EventArgs e)
        {
            await _LoadData();
        }

        private void cbManageDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = (cbManageDoctors.Text != "None")
                                 && (cbManageDoctors.Text != "Specialization");

            cbDoctorSpecialization.Visible = cbManageDoctors.Text == "Specialization";

            if (mtxtFilter.Visible)
            {
                mtxtFilter.Mask = "";
                mtxtFilter.Text = "";
                mtxtFilter.Focus();
            }

            if (cbManageDoctors.Text == "None")
                dgvManageDoctors.DataSource = _DoctorList;
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

                default:
                    _DoctorFilter = _DoctorList;
                    break;
            }

            dgvManageDoctors.DataSource = _DoctorFilter;
        }

        private void cbDoctorSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDoctorSpecialization.SelectedItem.ToString() == "All")
            {
                dgvManageDoctors.DataSource = _DoctorList;
                return;
            }

            _DoctorFilter = _DoctorList
                .Where(d => string.Equals(d.Specialization, cbDoctorSpecialization.SelectedItem))
                .ToList();

            dgvManageDoctors.DataSource = _DoctorFilter;
        }

        private async void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor(-1);

            frm.ShowDialog();

            await _LoadData();
        }

        private void pickDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pickedDoctorID = (int)dgvManageDoctors.CurrentRow.Cells[0].Value;

            DataBack?.Invoke(pickedDoctorID);

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvManageDoctors_DoubleClick(object sender, EventArgs e)
        {
            int pickedDoctorID = (int)dgvManageDoctors.CurrentRow.Cells[0].Value;

            DataBack?.Invoke(pickedDoctorID);

            Close();
        }
    }
}
