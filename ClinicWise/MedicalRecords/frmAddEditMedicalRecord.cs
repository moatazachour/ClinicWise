using ClinicWise.Appointments;
using ClinicWise.Business;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.Patients;
using ClinicWise.Global_Classes;
using ClinicWise.PrescriptionItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ClinicWise.MedicalRecords
{
    public partial class frmAddEditMedicalRecord : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _AppointmentID = -1;
        private int _MedicalRecordID;
        private List<clsPrescriptionItem> _MedicalRecordNewPrescriptions;
        private List<clsPrescriptionItem> _MedicalRecordAllPrescriptions;

        private clsMedicalRecord _MedicalRecord;

        public frmAddEditMedicalRecord(int medicalRecordID)
        {
            _MedicalRecordID = medicalRecordID;

            _Mode = (_MedicalRecordID == -1) ? enMode.AddNew : enMode.Update;

            InitializeComponent();
        }

        public void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Medical Record";
                _MedicalRecord = new clsMedicalRecord();
                _MedicalRecordAllPrescriptions = new List<clsPrescriptionItem>();
                _MedicalRecordNewPrescriptions = new List<clsPrescriptionItem>();
            }
            else
            {
                lblMode.Text = "Update Medical Record";
            }

            if (_AppointmentID == -1)
                lblAppointment.Text = "[Not selected yet]";

            txtVisitDescription.Text = null;
            txtDiagnosis.Text = null;
            txtAdditionalNotes.Text = null;

        }

        public async Task LoadByAppointmentIDAsync(int appointmentID)
        {
            _AppointmentID = appointmentID;
            MedicalRecordDTO medicalRecord = await clsMedicalRecord.FindByAppointmentIDAsync(_AppointmentID);

            AppointmentDTO appointment = await clsAppointment.FindAsync(appointmentID);
            PatientDTO patient = await clsPatient.FindAsync(appointment.PatientID);
            lblAppointment.Text = $"{appointment.AppointmentID} - {patient.FullName}";
            btnPickAppointment.Enabled = false;

            if (medicalRecord != null)
            {
                _MedicalRecordID = medicalRecord.RecordID;
                _MedicalRecord = new clsMedicalRecord(medicalRecord);
                _Mode = enMode.Update;

                switch (_MedicalRecord.VisitType)
                {
                    case clsMedicalRecord.enVisitType.Consultation:
                        cmbVisitType.SelectedItem = "Consultation";
                        break;
                    case clsMedicalRecord.enVisitType.FollowUp:
                        cmbVisitType.SelectedItem = "Follow up";
                        break;
                    case clsMedicalRecord.enVisitType.Emergency:
                        cmbVisitType.SelectedItem = "Emergency";
                        break;
                    case clsMedicalRecord.enVisitType.RoutineCheck:
                        cmbVisitType.SelectedItem = "Routine Check";
                        break;
                    case clsMedicalRecord.enVisitType.Vaccination:
                        cmbVisitType.SelectedItem = "Vaccination";
                        break;
                    case clsMedicalRecord.enVisitType.LabTest:
                        cmbVisitType.SelectedItem = "Lab Test";
                        break;
                    default:
                        break;
                }

                txtVisitDescription.Text = _MedicalRecord.DescriptionOfVisit;
                txtDiagnosis.Text = _MedicalRecord.Diagnosis;
                txtAdditionalNotes.Text = _MedicalRecord.AdditionalNotes;

                // NOTE: dgvPrescriptions should be loaded 
            }
        }

        public async Task _LoadDataAsync()
        {
            MedicalRecordDTO medicalRecordDTO = await clsMedicalRecord.FindAsync(_MedicalRecordID);

            if (medicalRecordDTO != null)
            {
                AppointmentDTO appointment = await clsAppointment.FindAsync(medicalRecordDTO.AppointmentID);
                PatientDTO patient = await clsPatient.FindAsync(appointment.PatientID);

                _MedicalRecordID = medicalRecordDTO.RecordID;
                _MedicalRecord = new clsMedicalRecord(medicalRecordDTO);
                _Mode = enMode.Update;

                lblAppointment.Text = $"{appointment.AppointmentID} - {patient.FullName}";

                switch (_MedicalRecord.VisitType)
                {
                    case clsMedicalRecord.enVisitType.Consultation:
                        cmbVisitType.SelectedItem = "Consultation";
                        break;
                    case clsMedicalRecord.enVisitType.FollowUp:
                        cmbVisitType.SelectedItem = "Follow up";
                        break;
                    case clsMedicalRecord.enVisitType.Emergency:
                        cmbVisitType.SelectedItem = "Emergency";
                        break;
                    case clsMedicalRecord.enVisitType.RoutineCheck:
                        cmbVisitType.SelectedItem = "Routine Check";
                        break;
                    case clsMedicalRecord.enVisitType.Vaccination:
                        cmbVisitType.SelectedItem = "Vaccination";
                        break;
                    case clsMedicalRecord.enVisitType.LabTest:
                        cmbVisitType.SelectedItem = "Lab Test";
                        break;
                    default:
                        break;
                }

                txtVisitDescription.Text = _MedicalRecord.DescriptionOfVisit;
                txtDiagnosis.Text = _MedicalRecord.Diagnosis;
                txtAdditionalNotes.Text = _MedicalRecord.AdditionalNotes;

                // NOTE: dgvPrescriptions should be loaded
            }
        }

        private async void frmAddEditMedicalRecord_Load(object sender, System.EventArgs e)
        {
            _ResetInformations();

            if (_Mode == enMode.Update)
                await _LoadDataAsync();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (_AppointmentID == -1)
            {
                MessageBox.Show(
                    "Appointment is necessary for medical record.", 
                    "Appointment Missing", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                return;
            }

            _MedicalRecord.AppointmentID = _AppointmentID;
            _MedicalRecord.DescriptionOfVisit = txtVisitDescription.Text;
            _MedicalRecord.Diagnosis = txtDiagnosis.Text;
            _MedicalRecord.AdditionalNotes = txtAdditionalNotes.Text;

            _MedicalRecord.VisitType = _GetVisitTypeFromComboBox();

            if (!_MedicalRecord.Save())
            {
                MessageBox.Show(
                    "Medical Record Saving Failed.",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            
            if (!clsPrescriptionItem.SaveItems(_MedicalRecordNewPrescriptions, _MedicalRecord.RecordID))
            {
                MessageBox.Show(
                    "Presciption Saving Failed.",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                    $"Medical Record with ID {_MedicalRecord.RecordID} Saved Successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            
            btnSave.Enabled = false;
            _Mode = enMode.Update;
            lblMode.Text = "Update Medical Record";
            this.Text = "Update Medical Record";
        }

        private clsMedicalRecord.enVisitType _GetVisitTypeFromComboBox()
        {
            switch (cmbVisitType.SelectedItem)
            {
                case "Consultation":
                    return clsMedicalRecord.enVisitType.Consultation;

                case "Follow up":
                    return clsMedicalRecord.enVisitType.FollowUp;

                case "Emergency":
                    return clsMedicalRecord.enVisitType.Emergency;

                case "Routine Check":
                    return clsMedicalRecord.enVisitType.RoutineCheck;

                case "Vaccination":
                    return clsMedicalRecord.enVisitType.Vaccination;

                case "Lab Test":
                    return clsMedicalRecord.enVisitType.LabTest;

                default:
                    clsGlobalSettings.LogInformation($"Combo box ever has an unexpected value: {cmbVisitType.SelectedItem}");
                    return clsMedicalRecord.enVisitType.Consultation;
            }
        }


        private void cmbVisitType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbVisitType.SelectedItem is null)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbVisitType, "What is the type of the visit!");
            }
            else
            {
                errorProvider1.SetError(cmbVisitType, null);
            }
        }

        private void btnAddPrescription_Click(object sender, System.EventArgs e)
        {
            frmAddEditPrescriptionItem frm = new frmAddEditPrescriptionItem(-1);
            frm.PrescriptionDataBack += PrescriptionAdded;
            frm.ShowDialog();
        }

        private void PrescriptionAdded(clsPrescriptionItem prescriptionItem)
        {
            if (_Mode == enMode.Update)
                prescriptionItem.MedicalRecordID = _MedicalRecordID;
            
            _MedicalRecordAllPrescriptions.Add(prescriptionItem);
            _MedicalRecordNewPrescriptions.Add(prescriptionItem);

            dgvPrescriptionItems.DataSource = _GetCleanPrescriptionView();
        }

        private List<MedicamentDTO> _GetCleanPrescriptionView()
        {
            return _MedicalRecordAllPrescriptions.Select(p => new MedicamentDTO(
                                                                p.MedicamentID ,
                                                                p.Medicament.Brand,
                                                                p.Medicament.Name,
                                                                p.Medicament.DosageForm)).ToList();
        }

        private void btnAppointmentDatails_Click(object sender, EventArgs e)
        {
            frmAppointmentDetails frm = new frmAppointmentDetails(_AppointmentID);
            frm.ShowDialog();
        }
    }
}
