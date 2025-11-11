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
        private int _UserID;

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsUser _User;

        public frmAddEditUser(int userID)
        {
            InitializeComponent();

            _UserID = userID;

            _Mode = _UserID == -1 ? enMode.AddNew : enMode.Update;
        }

        private void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                this.Text = "Add New User";

                _User = new clsUser();
                tabLoginInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();

                return;
            }
            else
            {
                lblMode.Text = "Update User";
                this.Text = "Update User";

                tabLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            lblUserID.Text = "N/A";
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private async Task _LoadData()
        {
            _User = new clsUser(await clsUser.FindAsync(_UserID));

            await ctrlPersonCardWithFilter1.LoadInformations(_User.PersonID);

            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.Username;
        }

        private async void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetInformations();

            if (_Mode == enMode.Update)
            {
                await _LoadData();
            }
        }

        

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tabLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                tcUsers.SelectedTab = tabLoginInfo;
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if (await clsUser.IsPersonAssignedToUserAccountAsync(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("This person already have a user account", "Select another Person",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ctrlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    tabLoginInfo.Enabled = true;
                    tcUsers.SelectedTab = tabLoginInfo;
                    btnSave.Enabled = true;
                }
                
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
            if (!ValidateChildren())
                return;

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
