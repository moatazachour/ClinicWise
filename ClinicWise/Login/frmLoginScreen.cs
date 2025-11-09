using ClinicWise.Business;
using ClinicWise.Contracts.Users;
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

namespace ClinicWise.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string hashedPassword = clsUtil.ComputeHash(txtPassword.Text.Trim());

            UserDTO user = await clsUser.FindByUsernameAndPasswordAsync(txtUserName.Text.Trim(), hashedPassword);

            if (user != null)
            {
                if (!user.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("User is inactive, please contact your admin!", "User Inactive",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                clsGlobalSettings.CurrentUserID = user.UserID;

                frmMain frm = new frmMain();
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
