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

namespace ClinicWise.Pharmacy
{
    public partial class frmAddEditMedicament : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private int _MedicamentId;
        private clsMedicament _Medicament;

        public frmAddEditMedicament(int medicamentID)
        {
            _MedicamentId = medicamentID;
            _Mode = _MedicamentId == -1 ? enMode.AddNew : enMode.Update;

            InitializeComponent();
        }

        private void _LoadDosageForms()
        {
            foreach (enDosageForm dosageForm in Enum.GetValues(typeof(enDosageForm)))
            {
                cbDosageForm.Items.Add(dosageForm);
            }
        }

        private void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Medicament";
                lblMode.Text = "Add New Medicament";
                _Medicament = new clsMedicament();
            }
            else
            {
                this.Text = "Update Medicament";
                lblMode.Text = "Update Medicament";
            }
            txtName.Text = string.Empty;
            txtBrand.Text = string.Empty;
            cbDosageForm.SelectedIndex = -1;
        }

        private async Task _LoadData()
        {
            MedicamentDTO medicament = await clsMedicament.FindAsync(_MedicamentId);

            if (medicament != null)
            {
                _Medicament = new clsMedicament(medicament);

                lblMedicamentID.Text = _Medicament.MedicamentID.ToString();
                txtName.Text = _Medicament.Name;
                txtBrand.Text = _Medicament.Brand ?? string.Empty;

                cbDosageForm.SelectedItem = _Medicament.DosageForm;
            }
        }

        private async void frmAddEditMedicament_Load(object sender, EventArgs e)
        {
            _LoadDosageForms();
            _ResetInformations();

            if (_Mode == enMode.Update)
                await _LoadData();
        }

        // Validations
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        private void cbDosageForm_Validating(object sender, CancelEventArgs e)
        {
            if (cbDosageForm.SelectedItem == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbDosageForm, "Choose Dosage Form!");
            }
            else
            {
                errorProvider1.SetError(cbDosageForm , null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Medicament.Name = txtName.Text;
            _Medicament.Brand = string.IsNullOrWhiteSpace(txtBrand.Text) ? null : txtBrand.Text.Trim();
            _Medicament.DosageForm = (enDosageForm)cbDosageForm.SelectedItem;

            if (_Medicament.Save())
            {
                MessageBox.Show(
                    $"Medicament Saved Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _Mode = enMode.Update;
                lblMedicamentID.Text = _Medicament.MedicamentID.ToString();
            }
            else
            {
                MessageBox.Show(
                    "Medicament Failed to be saved",
                    "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
    }
}
