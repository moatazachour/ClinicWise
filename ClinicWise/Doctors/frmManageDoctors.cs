using ClinicWise.Business;
using ClinicWise.Global_Classes;
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

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int doctorID = (int)dgvManageDoctors.CurrentRow.Cells[0].Value;

            if (MessageBox.Show(
                $"Are you sure you want to delete the doctor with ID [{doctorID}]",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information)
                == DialogResult.OK)
            {
                if (clsDoctor.Delete(doctorID, clsGlobalSettings.CurrentUserID))
                {
                    MessageBox.Show(
                        $"Doctor with ID = [{doctorID}] is deleted successfully",
                        "Succcess");

                    await _RefreshData();
                }
                else
                {
                    MessageBox.Show(
                        "Doctor deletion failed",
                        "Error",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);
                }

            }
        }
    }
}
