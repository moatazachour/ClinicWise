using ClinicWise.Business;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmAddEditDoctor : Form
    {
        private int _PersonID;

        private enum enGender { Male, Female }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        clsDoctor _Doctor;

        public frmAddEditDoctor(int personID)
        {
            InitializeComponent();

            _PersonID = personID;

            _Mode = (_PersonID == -1) ? enMode.AddNew : enMode.Update;
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

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            _Doctor = new clsDoctor();

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

            if (await _Doctor.SaveAsync())
            {
                MessageBox.Show($"Doctor ID = {_Doctor.DoctorID}", "Doctor Saved Successfully");
                _Mode = enMode.Update;
                lblDoctorID.Text = _Doctor.DoctorID.ToString();
            }
            else
            {
                MessageBox.Show("Doctor Failed to be saved", "Error");
            }

        }
    }
}
