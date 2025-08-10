using System;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmManageDoctors : Form
    {
        public frmManageDoctors()
        {
            InitializeComponent();
        }

        private void frmManageDoctors_Load(object sender, EventArgs e)
        {
            cbManageDoctors.SelectedItem = "None";
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor(-1);

            frm.ShowDialog();

            frmManageDoctors_Load(null, null);
        }
    }
}
