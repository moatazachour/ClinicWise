using ClinicWise.Doctors;
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
    }
}
