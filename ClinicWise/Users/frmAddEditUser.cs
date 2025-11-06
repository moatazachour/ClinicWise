using ClinicWise.Business;
using ClinicWise.Global_Classes;
using ClinicWise.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Users
{
    public partial class frmAddEditUser : Form
    {
        private int _PersonID;

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsUser _User;

        public frmAddEditUser(int personID)
        {
            InitializeComponent();

            _PersonID = personID;

            _Mode = _PersonID == -1 ? enMode.AddNew : enMode.Update;
        }

        private void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                _User = new clsUser();
            }
            else
            {
                lblMode.Text = "Update User";
            }

            lblUserID.Text = "N/A";
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetInformations();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                // TODO: Check if the user already exist
                _PersonID = ctrlPersonCardWithFilter1.PersonID;
                tcUsers.SelectedTab = tabLoginInfo;
                btnSave.Enabled = true;
                
            }
            else
            {
                MessageBox.Show("Choose a person first!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.PersonID = _PersonID;
            _User.Username = txtUserName.Text.Trim();
            _User.Password = clsUtil.ComputeHash(txtPassword.Text.Trim());
            _User.IsActive = chkIsActive.Checked;
            _User.CreatedByUserID = clsGlobalSettings.CurrentUserID;

            if (_User.Save())
            {
                MessageBox.Show(
                    $"User Saved Successfully",
                    "Success");

                _Mode = enMode.Update;
                lblUserID.Text = _User.UserID.ToString();
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show(
                    "User Failed to be saved",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!string.Equals(txtConfirmPassword.Text.Trim(), txtPassword.Text.Trim(), StringComparison.Ordinal))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username is empty!");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password is empty!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }
    }
}
