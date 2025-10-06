using ClinicWise.Business;
using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Patients
{
    public partial class frmManagePatients : Form
    {
        private List<PatientDisplayDTO> _PartientList;

        public frmManagePatients()
        {
            InitializeComponent();
        }

        private async Task _RefreshData()
        {
            cbManagePatients.SelectedItem = "None";
            _PartientList = await clsPatient.GetAllAsync();
            dgvManagePatients.DataSource = _PartientList;

            lblRecordCount.Text = dgvManagePatients.RowCount.ToString();

            mtxtFilter.Visible = false;

        }

        private async void frmManagePatients_Load(object sender, EventArgs e)
        {
            await _RefreshData();
        }

        private async void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient(-1);

            frm.ShowDialog();

            await _RefreshData();
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient(-1);

            frm.ShowDialog();

            await _RefreshData();
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient((int)dgvManagePatients.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _RefreshData();
        }
    }
}
