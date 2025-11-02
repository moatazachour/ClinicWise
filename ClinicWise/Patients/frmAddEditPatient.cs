using ClinicWise.Business;
using ClinicWise.Contracts.Guardians;
using ClinicWise.Contracts.Patients;
using ClinicWise.Global_Classes;
using ClinicWise.Guardians;
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
        private GuardianDTO _GuardianDTO;
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

            _GuardianDTO = await _Patient.GetGuardianInfo();

            if (_GuardianDTO != null)
            {
                lblGuardianID.Text = _Patient.GuardianID?.ToString() ?? "N/A";
                lblGuardianNationalNo.Text = _GuardianDTO.NationalNo ?? "N/A";
                lblGuardianPhone.Text = _GuardianDTO.Phone ?? "N/A";
            }



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

        private void _SaveData()
        {
            if (!_HandleImage())
                return;

            _Patient.FirstName = txtFirstName.Text;
            _Patient.LastName = txtLastName.Text;
            _Patient.NationalNo = txtNationalNo.Text;
            _Patient.DateOfBirth = dtpDateOfBirth.Value;
            _Patient.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _Patient.Phone = txtPhone.Text;
            _Patient.Email = txtEmail.Text;
            _Patient.Address = txtAddress.Text;
            _Patient.ImagePath = pbPatientImage.ImageLocation;
            _Patient.CreatedByUserID = clsGlobalSettings.CurrentUserID;


            if (int.TryParse(lblGuardianID.Text, out int guardianID))
                _Patient.GuardianID = guardianID;
            else
                _Patient.GuardianID = null;

            if (_Patient.Save())
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
                    "Patient Failed to be saved",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CheckIfPatientNeedAGuardian() && _GuardianDTO == null)
            {
                frmAddEditGuardian frm = new frmAddEditGuardian(-1);
                frm.DataBack += GuardianChanged;
                frm.ShowDialog();
            }

            _SaveData();

            // Dont forget the case when the patient is already a guardian (he already exist but but as a guardian),
            // So we don't get a duplicated persons in the database
        }

        private void GuardianChanged(GuardianDTO dto)
        {
            lblGuardianID.Text = dto.GuardianID.ToString();
            lblGuardianNationalNo.Text = dto.NationalNo;
            lblGuardianPhone.Text = dto.Phone;

            _SaveData();
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

        private void btnEditGuardian_Click(object sender, EventArgs e)
        {
            frmAddEditGuardian frm;

            if (lblGuardianID.Text != "N/A")
                frm = new frmAddEditGuardian(Convert.ToInt32(lblGuardianID.Text));
            else
                frm = new frmAddEditGuardian(-1);

            frm.DataBack += GuardianChanged;
            frm.ShowDialog(this);
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPatientImage.ImageLocation != null)
                pbPatientImage.Image = Resources.person_girl;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPatientImage.ImageLocation != null)
                pbPatientImage.Image = Resources.person_boy;
        }
    }
}
