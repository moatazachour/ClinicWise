using ClinicWise.Doctors;
using ClinicWise.Patients;
using System;
using System.Windows.Forms;

namespace ClinicWise
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
    }
}
