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
        private clsPrescriptionItem _NotPersistedItem;
        private int _MedicamentID;


        public frmAddEditPrescriptionItem(int prescriptionItemID, clsPrescriptionItem notPersitedItem = null)
        {
            InitializeComponent();

            _NotPersistedItem = notPersitedItem;
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
            else if (_Mode == enMode.Update)
            {
                lblMode.Text = "Update Prescription Item";
                this.Text = "Update Prescription Item";
            }

            lblPrescriptionItemID.Text = "N/A";
            lblMedicalRecordID.Text = "N/A";
            lblMedicament.Text = "[Not Selected Yet]";
            txtDosage.Text = string.Empty;
            txtFrequency.Text = string.Empty;
            nudDays.Value = 0;
            nudMonths.Value = 0;
            chkIsForever.Checked = false;
            txtSpecialInstructions.Text = string.Empty;
        }

        private async Task _LoadDataAsync()
        {
            PrescriptionItemDTO prescriptionItemDTO = await clsPrescriptionItem.FindAsync(_PrescriptionItemID);

            if (prescriptionItemDTO != null)
            {
                _PrescriptionItem = new clsPrescriptionItem(prescriptionItemDTO);
                _MedicamentID = prescriptionItemDTO.MedicamentID;

                lblPrescriptionItemID.Text = _PrescriptionItem.ItemID.ToString();
                lblMedicalRecordID.Text = _PrescriptionItem.MedicalRecordID.ToString();
                lblMedicament.Text = string.Format("{0}, {1} - {2}",
                    _PrescriptionItem.Medicament.Brand,
                    _PrescriptionItem.Medicament.Name,
                    _PrescriptionItem.Medicament.DosageForm.ToString());
                txtDosage.Text = _PrescriptionItem.DosageInfo.Dosage;
                txtFrequency.Text = _PrescriptionItem.DosageInfo.Frequency;
                txtSpecialInstructions.Text = _PrescriptionItem.DosageInfo.SpecialInstruction;
                nudDays.Value = _PrescriptionItem.DosageInfo.Duration.Days;
                nudMonths.Value = _PrescriptionItem.DosageInfo.Duration.Months;
                chkIsForever.Checked = _PrescriptionItem.DosageInfo.IsForever;
            }

        }

        private async void frmAddEditPrescriptionItem_Load(object sender, System.EventArgs e)
        {
            _ResetInformations();

            if (_Mode == enMode.Update)
                await _LoadDataAsync();

            if (_NotPersistedItem != null)
                _LoadNotPresistedItem();
        }

        private void _LoadNotPresistedItem()
        {
            if (_NotPersistedItem.ItemID != -1)
                lblPrescriptionItemID.Text = _NotPersistedItem.ItemID.ToString();

            if (_NotPersistedItem.MedicalRecordID != -1)
                lblMedicalRecordID.Text = _NotPersistedItem.MedicalRecordID.ToString();

            lblMedicament.Text = string.Format("{0}, {1} - {2}",
                    _NotPersistedItem.Medicament.Brand,
                    _NotPersistedItem.Medicament.Name,
                    _NotPersistedItem.Medicament.DosageForm.ToString());

            _MedicamentID = _NotPersistedItem.MedicamentID;
            btnPickMedicament.Enabled = false;

            txtDosage.Text = _NotPersistedItem.DosageInfo.Dosage;
            txtFrequency.Text = _NotPersistedItem.DosageInfo.Frequency;
            txtSpecialInstructions.Text = _NotPersistedItem.DosageInfo.SpecialInstruction;
            nudDays.Value = _NotPersistedItem.DosageInfo.Duration.Days;
            nudMonths.Value = _NotPersistedItem.DosageInfo.Duration.Months;
            chkIsForever.Checked = _NotPersistedItem.DosageInfo.IsForever;
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

        private stDosageInfo _LoadDosageInformations(clsPrescriptionItem prescriptionItem)
        {
            stDosageInfo dosageInfo = prescriptionItem.DosageInfo;

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
            if (_NotPersistedItem !=  null)
            {
                _NotPersistedItem.MedicamentID = _MedicamentID;
                _NotPersistedItem.DosageInfo = _LoadDosageInformations(_NotPersistedItem);
                PrescriptionDataBack?.Invoke(_NotPersistedItem);
                this.Close();
                return;
            }

            if (_MedicamentID == 0)
            {
                MessageBox.Show(
                    "Need to pick a medecine!",
                    "Medicine Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            if (_Mode == enMode.AddNew)
            {
                _PrescriptionItem.MedicamentID = _MedicamentID;
                _PrescriptionItem.DosageInfo = _LoadDosageInformations(_PrescriptionItem);
                PrescriptionDataBack?.Invoke(_PrescriptionItem);
                this.Close();
            }
            else
            {
                _PrescriptionItem.MedicamentID = _MedicamentID;
                _PrescriptionItem.DosageInfo = _LoadDosageInformations(_PrescriptionItem);

                if (!_PrescriptionItem.Save())
                {
                    MessageBox.Show(
                        "Prescription Update Failed!", 
                        "Failed", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }


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

        private void btnMedicamentDetails_Click(object sender, EventArgs e)
        {
            frmMedicamentDetails frm = new frmMedicamentDetails(_MedicamentID);
            frm.ShowDialog();
        }
    }
}
