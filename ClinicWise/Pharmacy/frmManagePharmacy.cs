using ClinicWise.Business;
using ClinicWise.Contracts.Medicaments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClinicWise.Business.clsAppointment;

namespace ClinicWise.Pharmacy
{
    public partial class frmManagePharmacy : Form
    {
        private List<MedicamentDTO> _MedicamentList;
        private List<MedicamentDTO> _MedicamentFilteredList;

        public frmManagePharmacy()
        {
            InitializeComponent();
        }

        private async Task _LoadDataAsync()
        {
            cbManagePharmacy.SelectedItem = "None";
            _MedicamentList = await clsMedicament.GetAllAsync();
            dgvManageMedicines.DataSource = _MedicamentList;
            lblRecordCount.Text = dgvManageMedicines.RowCount.ToString();
        }

        private void _LoadDosageForms()
        {
            foreach (enDosageForm dosageForm in Enum.GetValues(typeof(enDosageForm)))
            {
                cbDosageForm.Items.Add(dosageForm);
            }
        }

        private async void frmManagePharmacy_Load(object sender, EventArgs e)
        {
            _LoadDosageForms();
            await _LoadDataAsync();
        }

        private async void btnAddMedicine_Click(object sender, EventArgs e)
        {
            frmAddEditMedicament frm = new frmAddEditMedicament(-1);
            frm.ShowDialog();

            await _LoadDataAsync();
        }

        private async void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMedicament frm = new frmAddEditMedicament(-1);
            frm.ShowDialog();

            await _LoadDataAsync();
        }

        private void cbManagePharmacy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbManagePharmacy.SelectedItem.Equals("Name")
                || cbManagePharmacy.SelectedItem.Equals("Brand");
            cbDosageForm.Visible = cbManagePharmacy.SelectedItem.Equals("Dosage Form"); 

            if (cbManagePharmacy.SelectedItem.Equals("None"))
                dgvManageMedicines.DataSource = _MedicamentList;

            lblRecordCount.Text = dgvManageMedicines.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cbManagePharmacy.Text.Equals("Name"))
            {
                _MedicamentFilteredList = _MedicamentList
                        .Where(med => med.Name.StartsWith(txtFilter.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                        .ToList();
            }
                
            else if (cbManagePharmacy.Text.Equals("Brand"))
            {
                _MedicamentFilteredList = _MedicamentList
                        .Where(med => med.Brand.StartsWith(txtFilter.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();
            }
                
            dgvManageMedicines.DataSource = _MedicamentFilteredList;
            lblRecordCount.Text = dgvManageMedicines.RowCount.ToString();
        }

        private void cbDosageForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MedicamentFilteredList = _MedicamentList
                .Where(med => med.DosageForm.Equals(cbDosageForm.SelectedItem))
                .ToList();

            dgvManageMedicines.DataSource = _MedicamentFilteredList;
            lblRecordCount.Text = dgvManageMedicines.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
