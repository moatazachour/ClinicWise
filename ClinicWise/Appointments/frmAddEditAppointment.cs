using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Patients;
using ClinicWise.Contracts.Speciatizations;
using ClinicWise.Doctors;
using ClinicWise.Global_Classes;
using ClinicWise.Patients;
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

namespace ClinicWise.Appointments
{
    public partial class frmAddEditAppointment : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private DoctorDTO _Doctor;
        private PatientDTO _Patient;

        private clsAppointment _Appointment;

        public frmAddEditAppointment(int appointmentID)
        {
            InitializeComponent();

            _Mode = appointmentID == -1 ? enMode.AddNew : enMode.Update;
        }

        private void _ResetInformation()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Book an Appointment";
                _Appointment = new clsAppointment();
            }
            else
            {
                lblMode.Text = "Update an Appointment";
            }

            lblDoctorName.Text = "[Not chosen yet!]";
            lblPatientName.Text = "[Not chosen yet!]";
            dtpAppointmentDate.Value = DateTime.Today;
            dtpAppointmentTime.Value = DateTime.Now;
        }

        private void _LoadData()
        {

        }

        private void frmAddEditAppointment_Load(object sender, EventArgs e)
        {
            _ResetInformation();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnPickDoctor_Click(object sender, EventArgs e)
        {
            frmDoctorPicker frm = new frmDoctorPicker();

            frm.DataBack += DoctorPicked;

            frm.ShowDialog();
        }

        private async void DoctorPicked(int doctorID)
        {
            _Doctor = await clsDoctor.FindAsync(doctorID);
            clsSpecialization doctorSpecialization = await clsSpecialization.FindAsync(_Doctor.SpecializationID);

            lblDoctorName.Text = string.Format("{0} {1} - {2}",
                                                _Doctor.FirstName,
                                                _Doctor.LastName,
                                                doctorSpecialization.Name);
        }

        private void btnPickPatient_Click(object sender, EventArgs e)
        {
            frmPatientPicker frm = new frmPatientPicker();

            frm.DataBack += PatientPicked;

            frm.ShowDialog();
        }

        private async void PatientPicked(int patientID)
        {
            _Patient = await clsPatient.FindAsync(patientID);

            lblPatientName.Text = string.Format("{0} {1}", _Patient.FirstName, _Patient.LastName);
        }

        private void btnPatientDetails_Click(object sender, EventArgs e)
        {
            if (_Patient is null)
            {
                MessageBox.Show("Choose the patient first!", "Choose Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmPatientDetails frm = new frmPatientDetails(_Patient.PatientID);

            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Appointment.DoctorID = _Doctor.DoctorID;
            _Appointment.PatientID = _Patient.PatientID;
            _Appointment.Date = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;
            _Appointment.ScheduledByUserID = clsGlobalSettings.CurrentUserID;
            
            if (_Mode == enMode.AddNew)
            {
                if (MessageBox.Show(
                    "Is this confirmed? \n[Yes]: Confirmed\n[No]: Confirm Later",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Appointment.Status = enAppointmentStatus.Confirmed;
                }
                else
                {
                    _Appointment.Status = enAppointmentStatus.Pending;
                }
            }

            if (_Appointment.Save())
            {
                MessageBox.Show(
                    "Appointment saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _Mode = enMode.Update;
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show(
                    "Appointment saving failed!",
                    "Failure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
    }
}
