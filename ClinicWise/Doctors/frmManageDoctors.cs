using ClinicWise.Business;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmManageDoctors : Form
    {
        public frmManageDoctors()
        {
            InitializeComponent();
        }

        private async Task _RefreshData()
        {
            cbManageDoctors.SelectedItem = "None";

            dgvManageDoctors.DataSource = await clsDoctor.GetAllDoctorsAsync();

            lblRecordCount.Text = dgvManageDoctors.RowCount.ToString();
        }

        private async void frmManageDoctors_Load(object sender, EventArgs e)
        {
            await _RefreshData();
        }

        private async void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor(-1);
            frm.ShowDialog();

            await _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor((int)dgvManageDoctors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            await _RefreshData();
        }
    }
}
