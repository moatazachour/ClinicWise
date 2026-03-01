using ClinicWise.Appointments;
using ClinicWise.Business;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.Patients;
using ClinicWise.Contracts.PrescriptionItems;
using ClinicWise.PrescriptionItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.MedicalRecords.Controls
{
    public partial class ctrlMedicalRecordCard : UserControl
    {
        private int _AppointmentID;
        List<PrescriptionItemDisplayDTO> _MedicalRecordPrescriptionItems;

        public ctrlMedicalRecordCard()
        {
            InitializeComponent();
        }

        public async Task LoadMedicalRecordAsync(int medicalRecordID)
        {
            MedicalRecordFullViewDTO medicalRecord = await clsMedicalRecord.FindFullDataAsync(medicalRecordID);

            if (medicalRecord == null)
                return;

            lblMedicalRecordID.Text = medicalRecordID.ToString();
            lblAppointment.Text = await _GetAppointmentLabel(medicalRecord);
            _AppointmentID = medicalRecord.AppointmentID;
            lblVisitType.Text = medicalRecord.VisitType;
            lblVisitDescription.Text = medicalRecord.DescriptionOfVisit ?? "[N/A]";
            lblDiagnosis.Text = medicalRecord.Diagnosis ?? "[N/A]";
            lblAdditionalNotes.Text = medicalRecord.AdditionalNotes ?? "[N/A]";

            _MedicalRecordPrescriptionItems = await clsPrescriptionItem.GetAllByMedicalRecordAsync(medicalRecordID);
            dgvPrescriptionItems.DataSource = _GetCleanPrescriptionView(_MedicalRecordPrescriptionItems);
        }

        private List<MedicamentDTO> _GetCleanPrescriptionView(List<PrescriptionItemDisplayDTO> prescriptionDTOs)
        {
            List<clsPrescriptionItem> prescriptions = prescriptionDTOs.Select(p => new clsPrescriptionItem
            {
                ItemID = p.ItemID,
                MedicalRecordID = p.MedicalRecordID,
                MedicamentID = p.MedicamentID,
                DosageInfo = p.DosageInfo,
                IsNewlyAdded = false
            }).ToList();

            return prescriptions.Select(p => new MedicamentDTO(p.MedicamentID,
                                                               p.Medicament.Brand,
                                                               p.Medicament.Name,
                                                               p.Medicament.DosageForm)).ToList();
        }

        private async Task<string> _GetAppointmentLabel(MedicalRecordFullViewDTO medicalRecord)
        {
            AppointmentDTO appointment = await clsAppointment.FindAsync(medicalRecord.AppointmentID);
            PatientDTO patient = await clsPatient.FindAsync(appointment.PatientID);

            return $"{appointment.AppointmentID} - {patient.FullName}";
        }

        private void btnAppointmentDatails_Click(object sender, EventArgs e)
        {
            frmAppointmentDetails frm = new frmAppointmentDetails(_AppointmentID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_MedicalRecordPrescriptionItems.Count == 0)
                return;

            PrescriptionItemDisplayDTO prescriptionItem = _GetPrescriptionItem();

            if (prescriptionItem == null) return;

            frmPrescriptionItemDetails frm = new frmPrescriptionItemDetails(prescriptionItem.ItemID);
            frm.ShowDialog();
        }

        private PrescriptionItemDisplayDTO _GetPrescriptionItem()
        {
            foreach (PrescriptionItemDisplayDTO item in _MedicalRecordPrescriptionItems)
            {
                if (item.MedicamentID.Equals(dgvPrescriptionItems.CurrentRow.Cells[0].Value))
                    return item;
            }
            return null;
        }

    }
}
