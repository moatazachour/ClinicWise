using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Patients;
using ClinicWise.Contracts.Speciatizations;
using ClinicWise.Doctors;
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

namespace ClinicWise.Appointments
{
    public partial class frmAddEditAppointment : Form
    {
        private DoctorDTO _Doctor;
        private PatientDTO _Patient;

        public frmAddEditAppointment()
        {
            InitializeComponent();
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
    }
}
