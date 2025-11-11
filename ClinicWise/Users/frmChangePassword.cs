using ClinicWise.Business;
using ClinicWise.Global_Classes;
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
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private async void frmChangePassword_Load(object sender, EventArgs e)
        {
            await ctrlUserCard1.LoadDataAsync(clsGlobalSettings.CurrentUserID);

            _User = new clsUser(clsGlobalSettings.CurrentUser);

            txtCurrentPassword.Focus();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!string.Equals(
                clsUtil.ComputeHash(txtCurrentPassword.Text.Trim()),
                clsGlobalSettings.CurrentUser.Password))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "This is not you password!");
            }
            else if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Field is empty!");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.Equals(
                clsUtil.ComputeHash(txtNewPassword.Text.Trim()),
                clsGlobalSettings.CurrentUser.Password))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "This is the same password!");
            }
            else if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Field is empty!");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!string.Equals(txtNewPassword.Text.Trim(), txtConfirmNewPassword.Text.Trim(), StringComparison.Ordinal))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmNewPassword, "Password Confirmation does not match Password!");
            }
            else if (string.IsNullOrWhiteSpace(txtConfirmNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmNewPassword, "Field is empty!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmNewPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = clsUtil.ComputeHash(txtNewPassword.Text.Trim());

            if (_User.Save())
            {
                MessageBox.Show(
                    $"Password Saved Successfully",
                    "Success");

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
