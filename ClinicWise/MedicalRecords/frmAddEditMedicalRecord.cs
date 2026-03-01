using ClinicWise.Appointments;
using ClinicWise.Business;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.Patients;
using ClinicWise.Contracts.PrescriptionItems;
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
        public enum enMedicalRecordLoadMode { ByMedicalRecord, ByAppointment }
        private enMedicalRecordLoadMode _LoadMode;

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _AppointmentID;
        private int _MedicalRecordID;
        private List<clsPrescriptionItem> _MedicalRecordNewPrescriptions;
        private List<clsPrescriptionItem> _MedicalRecordAllPrescriptions;

        private clsMedicalRecord _MedicalRecord;

        public frmAddEditMedicalRecord(
            int medicalRecordID, 
            int appointmentID = -1, 
            enMedicalRecordLoadMode loadMode = enMedicalRecordLoadMode.ByMedicalRecord)
        {
            _MedicalRecordID = medicalRecordID;
            _AppointmentID = appointmentID;

            _Mode = (_MedicalRecordID == -1) ? enMode.AddNew : enMode.Update;
            _LoadMode = loadMode;

            InitializeComponent();
        }

        public void _ResetInformations()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Medical Record";
                _MedicalRecord = new clsMedicalRecord();
                _MedicalRecordAllPrescriptions = new List<clsPrescriptionItem>();
            }
            else
            {
                lblMode.Text = "Update Medical Record";
            }

            if (_AppointmentID == -1)
                lblAppointment.Text = "[Not selected yet]";

            _MedicalRecordNewPrescriptions = new List<clsPrescriptionItem>();

            txtVisitDescription.Text = null;
            txtDiagnosis.Text = null;
            txtAdditionalNotes.Text = null;
            btnAppointmentDatails.Enabled = _AppointmentID != -1;

        }

        public async Task _LoadByAppointmentIDAsync(int appointmentID)
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
                lblMedicalRecordID.Text = _MedicalRecordID.ToString();
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

                List<PrescriptionItemDisplayDTO> prescriptionItems = await clsPrescriptionItem.GetAllByMedicalRecordAsync(_MedicalRecordID);
                _MedicalRecordAllPrescriptions = prescriptionItems.Select(p => new clsPrescriptionItem
                {
                    ItemID = p.ItemID,
                    MedicalRecordID = p.MedicalRecordID,
                    MedicamentID = p.MedicamentID,
                    DosageInfo = p.DosageInfo,
                    IsNewlyAdded = false
                }).ToList();
                dgvPrescriptionItems.DataSource = _GetCleanPrescriptionView();
            }
        }

        public async Task _LoadDataAsync()
        {
            MedicalRecordDTO medicalRecordDTO = await clsMedicalRecord.FindAsync(_MedicalRecordID);

            if (medicalRecordDTO != null)
            {
                lblMedicalRecordID.Text = medicalRecordDTO.RecordID.ToString();

                _AppointmentID = medicalRecordDTO.AppointmentID;
                AppointmentDTO appointment = await clsAppointment.FindAsync(_AppointmentID);
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

                List<PrescriptionItemDisplayDTO> prescriptionItems = await clsPrescriptionItem.GetAllByMedicalRecordAsync(_MedicalRecordID);
                _MedicalRecordAllPrescriptions = prescriptionItems.Select(p => new clsPrescriptionItem
                {
                    ItemID = p.ItemID,
                    MedicalRecordID = p.MedicalRecordID,
                    MedicamentID = p.MedicamentID,
                    DosageInfo = p.DosageInfo,
                    IsNewlyAdded = false
                }).ToList();
                dgvPrescriptionItems.DataSource = _GetCleanPrescriptionView();
            }
        }

        private async void frmAddEditMedicalRecord_Load(object sender, System.EventArgs e)
        {
            _ResetInformations();

            if (_LoadMode == enMedicalRecordLoadMode.ByAppointment)
            {
                await _LoadByAppointmentIDAsync(_AppointmentID);
                return;
            }

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
            if (_MedicamenmentAlreadyExist(prescriptionItem))
            {
                MessageBox.Show(
                    $"{prescriptionItem.Medicament.Brand} - {prescriptionItem.Medicament.Name} already exist in your prescription.",
                    "Medicament Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_Mode == enMode.Update)
                prescriptionItem.MedicalRecordID = _MedicalRecordID;
            
            prescriptionItem.IsNewlyAdded = true;
            _MedicalRecordAllPrescriptions.Add(prescriptionItem);
            _MedicalRecordNewPrescriptions.Add(prescriptionItem);

            dgvPrescriptionItems.DataSource = _GetCleanPrescriptionView();
        }

        private bool _MedicamenmentAlreadyExist(clsPrescriptionItem prescriptionItem)
        {
            foreach (clsPrescriptionItem item in _MedicalRecordAllPrescriptions)
            {
                if (item.MedicamentID ==  prescriptionItem.MedicamentID)
                    return true;
            }

            return false;
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

        private void btnPickAppointment_Click(object sender, EventArgs e)
        {
            frmManageAppointments frm = new frmManageAppointments(frmManageAppointments.enAppointmentModeType.Picker);
            frm.AppointmentDataBack += _AppointmentPicked;
            frm.ShowDialog();
        }

        private void _AppointmentPicked(AppointmentDisplayDTO appointment)
        {
            _AppointmentID = appointment.AppointmentID;
            lblAppointment.Text = $"{_AppointmentID} - {appointment.PatientName}";
            btnAppointmentDatails.Enabled = true;
        }

        private clsPrescriptionItem _GetPrescriptionItem()
        {
            foreach (clsPrescriptionItem item in _MedicalRecordAllPrescriptions)
            {
                if (item.MedicamentID.Equals(dgvPrescriptionItems.CurrentRow.Cells[0].Value))
                    return item;
            }
            return null;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPrescriptionItem frm = new frmAddEditPrescriptionItem(-1);
            frm.PrescriptionDataBack += PrescriptionAdded;
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_MedicalRecordAllPrescriptions.Count == 0)
                return;

            clsPrescriptionItem prescriptionItem = _GetPrescriptionItem();

            if (prescriptionItem == null) return;

            frmAddEditPrescriptionItem frm;

            if (!prescriptionItem.IsNewlyAdded)
            {
                frm = new frmAddEditPrescriptionItem(prescriptionItem.ItemID);
            }
            else
            {
                prescriptionItem.ToUpdateANewlyAdded = true;
                frm = new frmAddEditPrescriptionItem(-1, prescriptionItem);
                frm.PrescriptionDataBack += PrescriptionUpdated;
            }
            frm.ShowDialog();
        }

        private void PrescriptionUpdated(clsPrescriptionItem item)
        {
            item.ToUpdateANewlyAdded = false;

            _SyncMedicalRecordAllPrescriptions(item);
            _SyncMedicalRecordNewPrescriptions(item);
        }

        private void _SyncMedicalRecordNewPrescriptions(clsPrescriptionItem item)
        {
            for (int i = 0; i < _MedicalRecordNewPrescriptions.Count; i++)
            {
                if (_MedicalRecordNewPrescriptions[i].ToUpdateANewlyAdded)
                {
                    _MedicalRecordNewPrescriptions[i] = item;
                    return;
                }
            }
        }

        private void _SyncMedicalRecordAllPrescriptions(clsPrescriptionItem item)
        {
            for (int i = 0; i < _MedicalRecordAllPrescriptions.Count; i++)
            {
                if (_MedicalRecordAllPrescriptions[i].ToUpdateANewlyAdded)
                {
                    _MedicalRecordAllPrescriptions[i] = item;
                    dgvPrescriptionItems.DataSource = _GetCleanPrescriptionView();
                    return;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPrescriptionItem prescriptionItem = _GetPrescriptionItem();

            if (MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!clsPrescriptionItem.Delete(prescriptionItem.ItemID))
                {

                }
            }

            
        }
    }
}
