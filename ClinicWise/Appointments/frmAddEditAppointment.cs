using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Appointments;
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
        private int _AppointmentID;

        public frmAddEditAppointment(int appointmentID)
        {
            InitializeComponent();

            _AppointmentID = appointmentID;

            _Mode = _AppointmentID == -1 ? enMode.AddNew : enMode.Update;
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

        private async Task _LoadData()
        {
            AppointmentDTO appointmentDTO = await clsAppointment.FindAsync(_AppointmentID);

            _Appointment = new clsAppointment(appointmentDTO);

            _Doctor = await clsDoctor.FindAsync(_Appointment.DoctorID);
            _Patient = await clsPatient.FindAsync(_Appointment.PatientID);

            lblDoctorName.Text = _Doctor.FullName;
            lblPatientName.Text = _Patient.FullName;

            if (_Appointment.Date.HasValue)
            {
                dtpAppointmentDate.Value = _Appointment.Date.Value.Date;
                dtpAppointmentTime.Value = _Appointment.Date.Value;
            }
        }

        private async void frmAddEditAppointment_Load(object sender, EventArgs e)
        {
            _ResetInformation();

            if (_Mode == enMode.Update)
                await _LoadData();
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_Doctor is null)
            {
                MessageBox.Show(
                    "Choose a doctor for the appointment!",
                    "Choose a doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (_Patient is null)
            {
                MessageBox.Show(
                    "Choose a patient for the appointment!",
                    "Choose a patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            _Appointment.DoctorID = _Doctor.DoctorID;
            _Appointment.PatientID = _Patient.PatientID;

            DateTime appointmentDate = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;

            if (!_Appointment.Date.Equals(appointmentDate))
            {
                _Appointment.Status = enAppointmentStatus.Rescheduled;
            }

            _Appointment.Date = appointmentDate;
            _Appointment.ScheduledByUserID = clsGlobalSettings.CurrentUserID;

            if (!ClinicHours.IsWithinBusinessHours((DateTime)_Appointment.Date))
            {
                MessageBox.Show(
                    "The selected appointment time is outside the clinic’s operating hours.\n\n" +
                    "Clinic Business Hours:\n" +
                    "  • Monday – Friday: 08:00 to 17:00\n" +
                    "  • Saturday: 09:00 to 13:00\n\n" +
                    "Please select a time within the allowed range.",
                    "Invalid Appointment Time",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!await _Appointment.IsDoctorAvailable())
            {
                if (MessageBox.Show(
                    $"Doctor {lblDoctorName.Text} is not available at {_Appointment.Date}\n" +
                    $"Click [OK] to check his schedule",
                    "Doctor Busy!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    == DialogResult.OK)
                {
                    frmDoctorDetails frm = new frmDoctorDetails(_Appointment.DoctorID);
                    frm.ShowDialog();
                }

                return;
            }

            if (!await _Appointment.IsPatientAvailable())
            {
                if (MessageBox.Show(
                    $"Patient {lblPatientName.Text} is already have an appointment at {_Appointment.Date}",
                    "Patient have an appointment!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    == DialogResult.OK)
                {
                    frmManageAppointments frm = new frmManageAppointments();
                    frm.LoadForPatient(_Appointment.PatientID);
                    frm.ShowDialog();

                }

                return;
            }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoctorDetails_Click(object sender, EventArgs e)
        {
            if (_Doctor is null)
            {
                MessageBox.Show(
                    "You should choose a doctor first!",
                    "Choose Doctor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            frmDoctorDetails frm = new frmDoctorDetails(_Doctor.DoctorID);
            frm.ShowDialog();
        }

        private void dtpAppointmentTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime value = dtpAppointmentTime.Value;
            int minutes = value.Minute < 30 ? 0 : 30;

            dtpAppointmentTime.Value =
                new DateTime(value.Year, value.Month, value.Day, value.Hour, minutes, 0);
        }
    }
}
