using ClinicWise.Business;
using ClinicWise.Contracts.Guardians;
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

namespace ClinicWise.Guardians
{
    public partial class frmAddEditGuardian : Form
    {
        public delegate void DataBackEventHandler(GuardianDTO guardianDTO);

        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew, Update };
        private enMode _Mode;

        private int _GuardianID;
        private clsGuardian _Guardian;
        private GuardianDTO _GuardianDTO;
        private GuardianRelationshipDTO _GuardianRelationshipDTO;

        private enum enGender { Male = 0, Female = 1 }

        public frmAddEditGuardian(int guardianID)
        {
            InitializeComponent();

            _GuardianID = guardianID;

            _Mode = _GuardianID == -1 ? enMode.AddNew : enMode.Update;
        }

        private async Task _LoadRelationships()
        {
            cbGuardianRelationships.Items.Clear();

            List<GuardianRelationshipDTO> guardianRelationships = await clsGuardianRelationship.GetAllAsync();

            foreach (var item in guardianRelationships)
            {
                cbGuardianRelationships.Items.Add(item.RelationshipName); 
            }

        }

        private async Task _ResetInformation()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Guardian";
                _Guardian = new clsGuardian();
            }
            else
            {
                lblMode.Text = "Update Guardian";
            }

            await _LoadRelationships();

            lblGuardianID.Text = "N/A";
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            pbGuardianImage.Image = rbMale.Checked ? Resources.person_boy : Resources.person_girl;
            llRemove.Visible = false;
        }
        
        private async Task _LoadData()
        {
            _GuardianDTO = await clsGuardian.FindAsync(_GuardianID);

            if (_GuardianDTO is null)
            {
                MessageBox.Show($"Guardian with ID {_GuardianID} Not Found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _Guardian = new clsGuardian(_GuardianDTO);

            lblGuardianID.Text = _Guardian.GuardianID.ToString();
            txtFirstName.Text = _Guardian.FirstName;
            txtLastName.Text = _Guardian.LastName;
            txtNationalNo.Text = _Guardian.NationalNo;
            dtpDateOfBirth.Value = _Guardian.DateOfBirth;
            rbMale.Checked = _Guardian.Gender == (int)enGender.Male;
            rbFemale.Checked = _Guardian.Gender == (int)enGender.Female;
            txtPhone.Text = _Guardian.Phone;
            txtEmail.Text = _Guardian.Email ?? string.Empty;
            txtAddress.Text = _Guardian.Address ?? string.Empty;

            _GuardianRelationshipDTO = await clsGuardianRelationship.FindAsync(_Guardian.RelashionshipID);
            cbGuardianRelationships.SelectedItem = _GuardianRelationshipDTO.RelationshipName;

            if (_Guardian.ImagePath != null)
            {
                pbGuardianImage.ImageLocation = _Guardian.ImagePath;
            }

            llRemove.Visible = (_Guardian.ImagePath != null);
        }

        private async void frmAddEditGuardian_Load(object sender, EventArgs e)
        {
            await _ResetInformation();

            if (_Mode == enMode.Update)
                await _LoadData();
        }

        private bool _HandleImage()
        {
            if (_Guardian.ImagePath != pbGuardianImage.ImageLocation)
            {
                if (_Guardian.ImagePath != null)
                {
                    try
                    {
                        File.Delete(_Guardian.ImagePath);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error Deleting Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }

                if (pbGuardianImage.ImageLocation != null)
                {
                    string sourceImage = pbGuardianImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImageFolder(ref sourceImage, enPersonType.Guardian))
                    {
                        pbGuardianImage.ImageLocation = sourceImage;
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

            _Guardian.FirstName = txtFirstName.Text;
            _Guardian.LastName = txtLastName.Text;
            _Guardian.NationalNo = txtNationalNo.Text;
            _Guardian.DateOfBirth = dtpDateOfBirth.Value;
            _Guardian.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _Guardian.Phone = txtPhone.Text;
            _Guardian.Email = txtEmail.Text;
            _Guardian.Address = txtAddress.Text;
            _Guardian.ImagePath = pbGuardianImage.ImageLocation;
            _Guardian.CreatedByUserID = clsGlobalSettings.CurrentUserID;

            GuardianRelationshipDTO relationship = clsGuardianRelationship.FindByName(cbGuardianRelationships.Text);
            _Guardian.RelashionshipID = relationship.GuardianRelationshipID;

            if (_Guardian.Save())
            {
                MessageBox.Show(
                    $"Guardian Saved Successfully",
                    "Success");

                DataBack?.Invoke(_Guardian.ToDTO());

                _Mode = enMode.Update;

                DialogResult = DialogResult.OK;
                Close();
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

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbGuardianImage.Load(selectedFilePath);
                llRemove.Visible = true;
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbGuardianImage.ImageLocation != null)
                pbGuardianImage.Image = Resources.person_boy;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbGuardianImage.ImageLocation != null)
                pbGuardianImage.Image = Resources.person_girl;
        }
    }
}
