using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmDoctorDetails : Form
    {
        private int _DoctorID;
        private List<AppointmentDisplayDTO> _AppointmentsList;

        public frmDoctorDetails(int doctorID)
        {
            InitializeComponent();

            _DoctorID = doctorID;
        }

        private async Task<List<AppointmentBasicDTO>> _LoadAppointments()
        {
            List<AppointmentDisplayDTO> appointmentsList = await clsAppointment.GetByDoctorAsync(_DoctorID);

            return appointmentsList
                .Select(a => new AppointmentBasicDTO
                (
                    a.AppointmentID,
                    a.PatientName,
                    a.Date,
                    a.StatusCaption
                ))
                .ToList();

        }

        private async Task _LoadData()
        {
            DoctorDTO doctorDTO = await clsDoctor.FindAsync(_DoctorID);
            clsDoctor doctor = new clsDoctor(doctorDTO);

            await ctrlPersonCard1.LoadPersonInfo(doctorDTO.ToPersonDTO());
            lblDoctorID.Text = doctorDTO.PersonID.ToString();
            clsSpecialization doctorSpecialization = await doctor.GetSpecializationInfo();
            lblSpecialization.Text = doctorSpecialization.Name;

            dgvAppointments.DataSource = await _LoadAppointments();
        }

        private async void frmDoctorDetails_Load(object sender, EventArgs e)
        {
            await _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void llEditDoctor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor(_DoctorID);
            frm.ShowDialog();

            await _LoadData();
        }

        
    }
}
