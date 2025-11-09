using ClinicWise.Business;
using ClinicWise.Contracts.Users;
using ClinicWise.Global_Classes;
using System;
using System.Windows.Forms;

namespace ClinicWise.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string Username = string.Empty, Password = string.Empty;

            if (clsGlobalSettings.GetStoredCredential(ref Username, ref Password))
            {
                txtUserName.Text = Username;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string hashedPassword = clsUtil.ComputeHash(txtPassword.Text.Trim());

            UserDTO user = await clsUser.FindByUsernameAndPasswordAsync(txtUserName.Text.Trim(), hashedPassword);

            if (user != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobalSettings.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobalSettings.RememberUsernameAndPassword(string.Empty, string.Empty);
                }

                if (!user.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("User is inactive, please contact your admin!", "User Inactive",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                clsGlobalSettings.CurrentUserID = user.UserID;

                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong Username/Password", "Wrong Credentials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUserName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
