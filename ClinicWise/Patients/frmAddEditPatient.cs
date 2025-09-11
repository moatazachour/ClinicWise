using ClinicWise.Business;
using ClinicWise.Contracts.Patients;
using ClinicWise.Global_Classes;
using ClinicWise.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Patients
{
    public partial class frmAddEditPatient : Form
    {
        private int _PatientID;
        private clsPatient _Patient;
        private PatientDTO _PatientDTO;
        private enum enMode { AddNew, Update };
        private enMode _Mode;

        private enum enGender { Male = 0, Female = 1 }

        public frmAddEditPatient(int patientID)
        {
            InitializeComponent();
            _PatientID = patientID;

            _Mode = _PatientID == -1 ? enMode.AddNew : enMode.Update;
        }

        private void _ResetInformation()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Patient";
                _Patient = new clsPatient();
            }
            else
            {
                lblMode.Text = "Update Patient";
            }

            lblPatientID.Text = "N/A";
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            pbPatientImage.Image = rbMale.Checked ? Resources.person_boy : Resources.person_girl;
            llRemove.Visible = false;

            lblGuardianID.Text = "N/A";
            lblGuardianNationalNo.Text = "N/A";
            lblGuardianPhone.Text = "N/A";
        }

        private async Task _LoadData()
        {
            _PatientDTO = await clsPatient.FindAsync(_PatientID);

            if (_PatientDTO is null)
            {
                MessageBox.Show($"Patient with ID {_Patient} Not Found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _Patient = new clsPatient(_PatientDTO);

            lblPatientID.Text = _Patient.PatientID.ToString();
            txtFirstName.Text = _Patient.FirstName;
            txtLastName.Text = _Patient.LastName;
            txtNationalNo.Text = _Patient.NationalNo;
            dtpDateOfBirth.Value = _Patient.DateOfBirth;
            rbMale.Checked = _Patient.Gender == (int)enGender.Male;
            rbFemale.Checked = _Patient.Gender == (int)enGender.Female;
            txtPhone.Text = _Patient.Phone;
            txtEmail.Text = _Patient.Email ?? string.Empty;
            txtAddress.Text = _Patient.Address ?? string.Empty;
            lblGuardianID.Text = _Patient.GuardianID?.ToString() ?? "N/A";
            //lblGuardianNationalNo.Text = _Patient
            // I can not process the line before until I finish implementing Guardians Classes

            if (_Patient.ImagePath != null)
            {
                pbPatientImage.ImageLocation = _Patient.ImagePath;
            }

            llRemove.Visible = (_Patient.ImagePath != null);
        }

        private async void frmAddEditPatient_Load(object sender, EventArgs e)
        {
            _ResetInformation();

            if (_Mode == enMode.Update)
                await _LoadData();
        }

        private bool _HandleImage()
        {
            if (_Patient.ImagePath != pbPatientImage.ImageLocation)
            {
                if (_Patient.ImagePath != null)
                {
                    try
                    {
                        File.Delete(_Patient.ImagePath);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error Deleting Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }

                if (pbPatientImage.ImageLocation != null)
                {
                    string sourceImage = pbPatientImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImageFolder(ref sourceImage, enPersonType.Patient))
                    {
                        pbPatientImage.ImageLocation = sourceImage;
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

        private bool _CheckIfPatientNeedAGuardian()
        {
            DateTime birthDate = dtpDateOfBirth.Value;
            DateTime currentDate = DateTime.Today;

            int yearDifference = currentDate.Year - birthDate.Year;
            int monthDifference = currentDate.Month - birthDate.Month;
            int dayDifference = currentDate.Day - birthDate.Day;

            if (yearDifference != 18)
            {
                return yearDifference < 18;
            }
           
            if (monthDifference == 0)
            {
                return dayDifference < 0;
            }

            return monthDifference < 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleImage())
                return;

            if (_CheckIfPatientNeedAGuardian())
            {
                MessageBox.Show("You need a guardian!!!");
                return;
            }

            _Patient.FirstName = txtFirstName.Text;
            _Patient.LastName = txtLastName.Text;
            _Patient.NationalNo = txtNationalNo.Text;
            _Patient.DateOfBirth = dtpDateOfBirth.Value;
            _Patient.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _Patient.Phone = txtPhone.Text;
            _Patient.Email = txtEmail.Text;
            _Patient.Address = txtAddress.Text;

            if (int.TryParse(lblGuardianID.Text, out int guardianID))
                _Patient.GuardianID = guardianID;
            else
                _Patient.GuardianID = null;

            if (await _Patient.SaveAsync())
            {
                MessageBox.Show(
                    $"Patient Saved Successfully",
                    "Success");


                _Mode = enMode.Update;
                lblPatientID.Text = _Patient.PatientID.ToString();
            }
            else
            {
                MessageBox.Show(
                    "Pateint Failed to be saved",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPatientImage.Load(selectedFilePath);
                llRemove.Visible = true;
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPatientImage.ImageLocation = null;

            pbPatientImage.Image = rbMale.Checked ? Resources.person_boy : Resources.person_girl;

            llRemove.Visible = false;
        }
    }
}
