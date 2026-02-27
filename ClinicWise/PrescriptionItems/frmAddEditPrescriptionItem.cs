using ClinicWise.Business;
using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.PrescriptionItems;
using ClinicWise.Pharmacy;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClinicWise.Pharmacy.frmManagePharmacy;

namespace ClinicWise.PrescriptionItems
{
    public partial class frmAddEditPrescriptionItem : Form
    {
        public event Action<clsPrescriptionItem> PrescriptionDataBack;
        
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private int _PrescriptionItemID;
        private clsPrescriptionItem _PrescriptionItem;
        private int _MedicamentID;


        public frmAddEditPrescriptionItem(int prescriptionItemID)
        {
            InitializeComponent();

            _PrescriptionItemID = prescriptionItemID;
            _Mode = _PrescriptionItemID == -1 ? enMode.AddNew : enMode.Update;
        }

        private void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Prescription Item";
                this.Text = "Add New Prescription Item";
                _PrescriptionItem = new clsPrescriptionItem();
            }
            else if(_Mode == enMode.Update)
            {
                lblMode.Text = "Update Prescription Item";
                this.Text = "Update Prescription Item";
            }

            lblPrescriptionItemID.Text = "[????]";
            lblMedicalRecordID.Text = "[????]";
            lblMedicament.Text = "[Not Selected Yet]";
            txtDosage.Text = string.Empty;
            txtFrequency.Text = string.Empty;
            nudDays.Value = 0;
            nudMonths.Value = 0;
            chkIsForever.Checked = false;
            txtSpecialInstructions.Text = string.Empty;
        }

        private Task _LoadDataAsync()
        {
            // Not Implemented yet.
            return Task.FromResult(0); 
        }

        private async void frmAddEditPrescriptionItem_Load(object sender, System.EventArgs e)
        {
            _ResetInformations();

            if (_Mode == enMode.AddNew)
                await _LoadDataAsync();
        }

        private void btnPickMedicament_Click(object sender, System.EventArgs e)
        {
            frmManagePharmacy frm = new frmManagePharmacy(enPharmacyMode.Picker);
            frm.DataBack += MedicamentPicked;
            frm.ShowDialog();
        }

        private async void MedicamentPicked(int medicamentID)
        {
            MedicamentDTO medicament = await clsMedicament.FindAsync(medicamentID);
            _MedicamentID = medicamentID;
            lblMedicament.Text = string.Format("{0}, {1} - {2}", medicament.Brand, medicament.Name, medicament.DosageForm.ToString());
        }

        private stDosageInfo _LoadDosageInformations()
        {
            stDosageInfo dosageInfo = _PrescriptionItem.DosageInfo;
            
            dosageInfo.Dosage = txtDosage.Text;
            dosageInfo.Frequency = txtFrequency.Text;
            stDurationPeriod duration = dosageInfo.Duration;
            duration.Days = Convert.ToByte(nudDays.Value);
            duration.Months = Convert.ToByte(nudMonths.Value);
            dosageInfo.Duration = duration;
            dosageInfo.SpecialInstruction = txtSpecialInstructions.Text;
            dosageInfo.IsForever = chkIsForever.Checked;

            return dosageInfo;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (_MedicamentID == 0)
            {
                MessageBox.Show(
                    "Need to pick a medecine!",
                    "Medicine Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                return;
            }
            _PrescriptionItem.MedicamentID = _MedicamentID;
            _PrescriptionItem.DosageInfo = _LoadDosageInformations();

            PrescriptionDataBack?.Invoke(_PrescriptionItem);
            this.Close();
        }

        private void chkIsForever_CheckedChanged(object sender, EventArgs e)
        {
            nudDays.Enabled = !chkIsForever.Checked;
            nudMonths.Enabled = !chkIsForever.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
