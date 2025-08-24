using ClinicWise.Business;
using ClinicWise.Contracts;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Doctors
{
    public partial class frmDoctorDetails : Form
    {
        private int _DoctorID;

        public frmDoctorDetails(int doctorID)
        {
            InitializeComponent();

            _DoctorID = doctorID;
        }

        private async Task _LoadData()
        {
            DoctorDTO doctorDTO = await clsDoctor.FindAsync(_DoctorID);
            clsDoctor doctor = new clsDoctor(doctorDTO);

            ctrlPersonCard1.LoadPersonInfo(doctorDTO.ToPersonDTO());
            lblDoctorID.Text = doctorDTO.PersonID.ToString();
            clsSpecialization doctorSpecialization = await doctor.GetSpecializationInfo();
            lblSpecialization.Text = doctorSpecialization.Name;
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
