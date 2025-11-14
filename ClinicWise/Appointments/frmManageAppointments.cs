using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClinicWise.Business.clsAppointment;

namespace ClinicWise.Appointments
{
    public partial class frmManageAppointments : Form
    {
        private List<AppointmentDisplayDTO> _AppointmentsList;
        private List<AppointmentDisplayDTO> _AppointmentsFilter;

        public frmManageAppointments()
        {
            InitializeComponent();
        }

        private async Task _LoadDoctors()
        {
            List<DoctorDisplayDTO> doctors = await clsDoctor.GetAllDoctorsAsync();

            foreach (var doctor in doctors)
            {
                cbDoctors.Items.Add(string.Join(" - ", doctor.FullName, doctor.Specialization));
            }
        }

        private async Task _LoadPatients()
        {
            List<PatientDisplayDTO> patients = await clsPatient.GetAllAsync();

            foreach (var patient in patients)
            {
                cbPatients.Items.Add(patient.FullName);
            }
        }

        private async Task _RefreshData()
        {
            await _LoadDoctors();
            await _LoadPatients();

            _AppointmentsList = await clsAppointment.GetAllAsync();

            cbManageAppointments.SelectedItem = "None";

            dgvManageAppointments.DataSource = _AppointmentsList;
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

        private void cbManageAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = cbManageAppointments.SelectedItem.Equals("Appointment ID");
            cbAppointmentStatus.Visible = cbManageAppointments.SelectedItem.Equals("Status");
            cbDoctors.Visible = cbManageAppointments.SelectedItem.Equals("Doctor");
            cbPatients.Visible = cbManageAppointments.SelectedItem.Equals("Patient");

            if (cbManageAppointments.SelectedItem.Equals("None"))
                dgvManageAppointments.DataSource = _AppointmentsList;

            dgvManageAppointments.DataSource = _AppointmentsList;
            lblRecordCount.Text = dgvManageAppointments.Rows.Count.ToString();
        }

        private void mtxtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cbManageAppointments.SelectedItem.Equals("Appointment ID"))
            {
                if (int.TryParse(mtxtFilter.Text.Trim(), out int appointmentID))
                    _AppointmentsFilter = _AppointmentsList.Where(a => a.AppointmentID.Equals(Convert.ToInt32(mtxtFilter.Text.Trim()))).ToList();
                else
                    _AppointmentsFilter = _AppointmentsList;
            }
            
            dgvManageAppointments.DataSource = _AppointmentsFilter;
            lblRecordCount.Text = dgvManageAppointments.RowCount.ToString();
        }

        private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbManageAppointments.Text == "Appointment ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbAppointmentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbAppointmentStatus.SelectedItem)
            {
                case "Pending":
                    _AppointmentsFilter = _AppointmentsList
                        .Where(a => a.StatusCaption.Equals(enAppointmentStatus.Pending.ToString())).ToList();
                    break;

                case "Confirmed":
                    _AppointmentsFilter = _AppointmentsList
                        .Where(a => a.StatusCaption.Equals(enAppointmentStatus.Confirmed.ToString())).ToList();
                    break;

                case "Completed":
                    _AppointmentsFilter = _AppointmentsList
                        .Where(a => a.StatusCaption.Equals(enAppointmentStatus.Completed.ToString())).ToList();
                    break;

                case "Cancelled":
                    _AppointmentsFilter = _AppointmentsList
                        .Where(a => a.StatusCaption.Equals(enAppointmentStatus.Cancelled.ToString())).ToList();
                    break;

                case "Rescheduled":
                    _AppointmentsFilter = _AppointmentsList
                        .Where(a => a.StatusCaption.Equals(enAppointmentStatus.Rescheduled.ToString())).ToList();
                    break;

                case "NoShow":
                    _AppointmentsFilter = _AppointmentsList
                        .Where(a => a.StatusCaption.Equals(enAppointmentStatus.NoShow.ToString())).ToList();
                    break;

                default:
                    _AppointmentsFilter = _AppointmentsList;
                    break;
            }

            dgvManageAppointments.DataSource = _AppointmentsFilter;
            lblRecordCount.Text = dgvManageAppointments.RowCount.ToString();
        }

        private void cbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            _AppointmentsFilter = _AppointmentsList
                .Where(a => a.PatientName.Equals(cbPatients.SelectedItem.ToString()))
                .ToList();

            dgvManageAppointments.DataSource = _AppointmentsFilter;
            lblRecordCount.Text = dgvManageAppointments.RowCount.ToString();
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _AppointmentsFilter = _AppointmentsList
                .Where(a => a.DoctorFullLabel.Equals(cbDoctors.SelectedItem.ToString()))
                .ToList();

            dgvManageAppointments.DataSource = _AppointmentsFilter;
            lblRecordCount.Text = dgvManageAppointments.RowCount.ToString();
        }
    }
}
