using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Global_Classes;
using ClinicWise.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
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

        private async Task _ResetInformations()
        {
            await _LoadMedicalSpecializations();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Doctor";
                _Doctor = new clsDoctor();
            }
            else
            {
                lblMode.Text = "Update Doctor";
            }

            lblDoctorID.Text = "N/A";
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            pbDoctorImage.Image = rbMale.Checked ? Resources.doctor_maleV2 : Resources.doctor_femaleV2;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;

            llRemove.Visible = false;
        }

        private async Task _LoadData()
        {
            DoctorDTO doctorDto = await clsDoctor.FindAsync(_DoctorID);

            if (doctorDto is null)
            {
                MessageBox.Show($"Doctor with ID {_DoctorID} Not Found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _Doctor = new clsDoctor(doctorDto);


            lblDoctorID.Text = _DoctorID.ToString();
            txtFirstName.Text = _Doctor.FirstName;
            txtLastName.Text = _Doctor.LastName;
            txtNationalNo.Text = _Doctor.NationalNo;
            dtpDateOfBirth.Value = _Doctor.DateOfBirth;
            rbMale.Checked = _Doctor.Gender == 0;
            rbFemale.Checked = _Doctor.Gender == 1;
            txtPhone.Text = _Doctor.Phone;
            clsSpecialization specialization = await _Doctor.GetSpecializationInfo();
            cbSpecialization.SelectedItem = specialization.Name;
            txtEmail.Text = _Doctor.Email ?? string.Empty;
            txtAddress.Text = _Doctor.Address ?? string.Empty;

            if (_Doctor.ImagePath != null)
            {
                pbDoctorImage.ImageLocation = _Doctor.ImagePath;
            }

            llRemove.Visible = (_Doctor.ImagePath != null);
        }

        private async void frmAddEditDoctor_Load(object sender, EventArgs e)
        {
            await _ResetInformations();

            if (_Mode == enMode.Update)
                await _LoadData();
        }

        private bool _HandleImage()
        {
            if (_Doctor.ImagePath != pbDoctorImage.ImageLocation)
            {
                if (_Doctor.ImagePath != null)
                {
                    try
                    {
                        File.Delete(_Doctor.ImagePath);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error Deleting Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }

                if (pbDoctorImage.ImageLocation != null)
                {
                    string sourceImage = pbDoctorImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImageFolder(ref sourceImage, enPersonType.Doctor))
                    {
                        pbDoctorImage.ImageLocation = sourceImage;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleImage())
                return;

            _Doctor.NationalNo = txtNationalNo.Text;
            _Doctor.FirstName = txtFirstName.Text;
            _Doctor.LastName = txtLastName.Text;
            _Doctor.DateOfBirth = dtpDateOfBirth.Value;
            _Doctor.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _Doctor.Phone = txtPhone.Text;
            _Doctor.Email = txtEmail.Text;
            _Doctor.Address = txtAddress.Text;
            _Doctor.ImagePath = pbDoctorImage.ImageLocation;
            _Doctor.CreatedByUserID = clsGlobalSettings.CurrentUserID;

            clsSpecialization specialization = await clsSpecialization.FindByNameAsync(cbSpecialization.Text);
            _Doctor.SpecializationID = specialization.SpecializationID;

            if (_Doctor.Save())
            {
                MessageBox.Show(
                    $"Doctor Saved Successfully", 
                    "Success");


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

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbDoctorImage.Image = Resources.doctor_maleV2;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbDoctorImage.Image = Resources.doctor_femaleV2;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbDoctorImage.Load(selectedFilePath);
                llRemove.Visible = true;
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbDoctorImage.ImageLocation = null;

            pbDoctorImage.Image =  rbMale.Checked ? Resources.doctor_maleV2 : Resources.doctor_femaleV2;

            llRemove.Visible = false;
        }

        // Validation

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This field is required!");
            }
            else if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Incorrect email format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
            }
            else if (clsDoctor.IsExistByNationalNo(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "There is already a doctor with this NationalNo!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }
    }
}
