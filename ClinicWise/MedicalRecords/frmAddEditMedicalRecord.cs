using ClinicWise.Business;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Patients;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.MedicalRecords
{
    public partial class frmAddEditMedicalRecord : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _AppointmentID;
        private int _MedicalRecordID;

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
            }
            else
            {
                lblMode.Text = "Update Medical Record";
            }

            lblAppointment.Text = "[Not selected yet]";
            txtVisitDescription.Text = null;
            txtDiagnosis.Text = null;
            txtAdditionalNotes.Text = null;
        }

        public async Task LoadByAppointmentIDAsync(int appointmentID)
        {
            _AppointmentID = appointmentID;
            MedicalRecordDTO medicalRecord = await clsMedicalRecord.FindByAppointmentID(_AppointmentID);

            if (medicalRecord != null)
            {
                AppointmentDTO appointment = await clsAppointment.FindAsync(appointmentID);
                PatientDTO patient = await clsPatient.FindAsync(appointment.PatientID);

                _MedicalRecordID = medicalRecord.RecordID;
                _MedicalRecord = new clsMedicalRecord(medicalRecord);
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

        //adding new medical record need to be done
    }
}
