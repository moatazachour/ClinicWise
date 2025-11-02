using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Persons;
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

namespace ClinicWise.Persons
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void DataBackEventHandler(int personID);

        public event DataBackEventHandler DataBack;

        private int _PersonID;

        private enum enGender { Male, Female }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsPerson _Person;

        public frmAddEditPerson(int personID)
        {
            InitializeComponent();

            _PersonID = personID;

            _Mode = (_PersonID == -1) ? enMode.AddNew : enMode.Update;
        }

        private void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblMode.Text = "Update Person";
            }

            lblPersonID.Text = "N/A";
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            pbPersonImage.Image = rbMale.Checked ? Resources.person_boy : Resources.person_girl;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;

            llRemove.Visible = false;
        }

        private async Task _LoadData()
        {
            PersonDTO personDTO = await clsPerson.FindAsync(_PersonID);

            if (personDTO is null)
            {
                MessageBox.Show($"Person with ID {_PersonID} Not Found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _Person = new clsPerson(personDTO);

            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            rbMale.Checked = _Person.Gender == 0;
            rbFemale.Checked = _Person.Gender == 1;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email ?? string.Empty;
            txtAddress.Text = _Person.Address ?? string.Empty;

            if (_Person.ImagePath != null)
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            llRemove.Visible = (_Person.ImagePath != null);
        }

        private async void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetInformations();

            if (_Mode == enMode.Update)
                await _LoadData();
        }

        private bool _HandleImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != null)
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error Deleting Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    string sourceImage = pbPersonImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImageFolder(ref sourceImage, enPersonType.Staff))
                    {
                        pbPersonImage.ImageLocation = sourceImage;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleImage())
                return;

            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            _Person.ImagePath = pbPersonImage.ImageLocation;
            _Person.CreatedByUserID = clsGlobalSettings.CurrentUserID;

            if (_Person.Save())
            {
                MessageBox.Show(
                    $"Person Saved Successfully",
                    "Success");

                DataBack?.Invoke(_Person.PersonID);

                _Mode = enMode.Update;
                lblPersonID.Text = _Person.PersonID.ToString();
            }
            else
            {
                MessageBox.Show(
                    "Person Failed to be saved",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.person_boy;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Resources.person_girl;
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
                pbPersonImage.Load(selectedFilePath);
                llRemove.Visible = true;
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            pbPersonImage.Image = rbMale.Checked ? Resources.person_boy : Resources.person_girl;

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

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
            }
            else if (clsPerson.IsExistByNationalNo(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "There is already a person with this NationalNo!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
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

        
    }
}
