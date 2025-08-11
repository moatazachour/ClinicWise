using ClinicWise.Business;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmAddEditDoctor : Form
    {
        private int _DoctorID;

        private enum enGender { Male, Female }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsDoctor _Doctor;

        public frmAddEditDoctor(int doctorID)
        {
            InitializeComponent();

            _DoctorID = doctorID;

            _Mode = (_DoctorID == -1) ? enMode.AddNew : enMode.Update;
        }

        private async Task _LoadMedicalSpecializations()
        {
            DataTable allSpecialization = await clsSpecialization.GetAllAsync();

            foreach (DataRow row in allSpecialization.Rows)
            {
                cbSpecialization.Items.Add(row["Name"]);
            }
        }

        private async void frmAddEditDoctor_Load(object sender, EventArgs e)
        {
            await _LoadMedicalSpecializations();

            if (_Mode == enMode.AddNew)
            {
                return;
            }

            _Doctor = await clsDoctor.FindAsync(_DoctorID);

            if (_Doctor is null)
            {
                MessageBox.Show($"Doctor with ID {_DoctorID} Not Found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            lblDoctorID.Text = _DoctorID.ToString();
            txtFirstName.Text = _Doctor.FirstName;
            txtLastName.Text = _Doctor.LastName;
            txtNationalNo.Text = _Doctor.NationalNo;
            dtpDateOfBirth.Value = _Doctor.DateOfBirth;
            rbMale.Checked = _Doctor.Gender == 0;
            rbFemale.Checked = _Doctor.Gender == 1;
            txtPhone.Text = _Doctor.Phone;
            clsSpecialization specialization = await clsSpecialization.FindAsync(_Doctor.SpecializationID);
            cbSpecialization.SelectedItem = specialization.Name;
            txtEmail.Text = _Doctor.Email;
            txtAddress.Text = _Doctor.Address;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _Doctor = new clsDoctor();
            }

            _Doctor.NationalNo = txtNationalNo.Text;
            _Doctor.FirstName = txtFirstName.Text;
            _Doctor.LastName = txtLastName.Text;
            _Doctor.DateOfBirth = dtpDateOfBirth.Value;
            _Doctor.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _Doctor.Phone = txtPhone.Text;
            _Doctor.Email = txtEmail.Text;
            _Doctor.Address = txtAddress.Text;

            clsSpecialization specialization = await clsSpecialization.FindByNameAsync(cbSpecialization.Text);
            _Doctor.SpecializationID = specialization.SpecializationID;

            if (_Doctor.Save())
            {
                MessageBox.Show(
                    $"Doctor ID = {_Doctor.DoctorID}", 
                    "Doctor Saved Successfully");


                _Mode = enMode.Update;
                lblDoctorID.Text = _Doctor.DoctorID.ToString();
            }
            else
            {
                MessageBox.Show(
                    "Doctor Failed to be saved", 
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }

        }
    }
}
