using ClinicWise.Business;
using ClinicWise.Contracts.PrescriptionItems;
using ClinicWise.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.PrescriptionItems.Controls
{
    public partial class ctrlPrescriptionItemCard : UserControl
    {
        private int _MedicamentID;

        public ctrlPrescriptionItemCard()
        {
            InitializeComponent();
        }

        public async Task LoadPrescriptionItemData(int prescriptionItemID)
        {
            PrescriptionItemDTO prescriptionItemDTO = await clsPrescriptionItem.FindAsync(prescriptionItemID);
            clsPrescriptionItem prescriptionItem = new clsPrescriptionItem(prescriptionItemDTO);

            _MedicamentID = prescriptionItem.MedicamentID;

            lblPrescriptionItemID.Text = prescriptionItemID.ToString();
            lblMedicalRecordID.Text = prescriptionItem.MedicalRecordID.ToString();
            lblMedicament.Text = prescriptionItem.Medicament.ToString();
            lblDosage.Text = prescriptionItem.DosageInfo.Dosage;
            lblFrequency.Text = prescriptionItem.DosageInfo.Frequency;
            lblDuration.Text = prescriptionItem.DosageInfo.DurationDisplay;
            lblIsForever.Text = prescriptionItem.DosageInfo.IsForever ? "Yes" : "No";

            string specialInstruction = prescriptionItem.DosageInfo.SpecialInstruction;
            lblSpcialInstructions.Text = specialInstruction;
        }
        private void btnMedicamentDetails_Click(object sender, EventArgs e)
        {
            frmMedicamentDetails frm = new frmMedicamentDetails(_MedicamentID);
            frm.ShowDialog();
        }
    }
}
