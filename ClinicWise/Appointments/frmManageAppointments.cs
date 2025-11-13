using ClinicWise.Business;
using ClinicWise.Contracts.Appointments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Appointments
{
    public partial class frmManageAppointments : Form
    {
        private List<AppointmentDisplayDTO> _AppointmentList;

        public frmManageAppointments()
        {
            InitializeComponent();
        }

        private async Task _RefreshData()
        {
            _AppointmentList = await clsAppointment.GetAllAsync();

            dgvManageAppointments.DataSource = _AppointmentList;
        }

        private async void frmManageAppointments_Load(object sender, EventArgs e)
        {
            await _RefreshData();
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditAppointment frm = new frmAddEditAppointment(-1);

            frm.ShowDialog();

            await _RefreshData();
        }
    }
}
