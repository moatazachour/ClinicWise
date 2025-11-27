using ClinicWise.Business;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Doctors;
using ClinicWise.Patients;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Appointments.Controls
{
    public partial class ctrlAppointmentDetails : UserControl
    {
        private AppointmentDisplayDTO _AppointmentDTO;

        public ctrlAppointmentDetails()
        {
            InitializeComponent();
        }

        public async Task LoadAppointmentInformations(int appointmentID)
        {
            _AppointmentDTO = await clsAppointment.FindDetailedAsync(appointmentID);

            lblAppointmentID.Text = appointmentID.ToString();
            lblDoctor.Text = _AppointmentDTO.DoctorFullLabel;
            lblPatient.Text = _AppointmentDTO.PatientName;
            lblDate.Text = _AppointmentDTO.Date?.ToString("dd/MM/yyyy HH:mm") ?? "Not scheduled yet";
            lblStatus.Text = _AppointmentDTO.StatusCaption;
            lblScheduledBy.Text = _AppointmentDTO.ScheduledBy;
        }

        private void btnDoctorDetails_Click(object sender, EventArgs e)
        {
            frmDoctorDetails frm = new frmDoctorDetails(_AppointmentDTO.DoctorID);
            frm.ShowDialog();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            frmPatientDetails frm = new frmPatientDetails(_AppointmentDTO.PatientID);
            frm.ShowDialog();
        }
    }
}
