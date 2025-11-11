using ClinicWise.Doctors;
using ClinicWise.Global_Classes;
using ClinicWise.Login;
using ClinicWise.Patients;
using ClinicWise.Users;
using System;
using System.Windows.Forms;

namespace ClinicWise
{
    public partial class frmMain : Form
    {
        private frmLoginScreen _loginScreen;

        public frmMain(frmLoginScreen frm)
        {
            InitializeComponent();

            _loginScreen = frm;
        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDoctors frm = new frmManageDoctors();

            frm.ShowDialog();
        }

        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePatients frm = new frmManagePatients();

            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();

            frm.ShowDialog();
        }

        private void currentUserInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobalSettings.CurrentUserID);

            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CurrentUserID = -1;
            clsGlobalSettings.CurrentUser = null;
            _loginScreen.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();

            frm.ShowDialog();
        }
    }
}
