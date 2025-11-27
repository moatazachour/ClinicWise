using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClinicWise.Business.clsAppointment;

namespace ClinicWise.Appointments
{
    public partial class frmManageAppointments : Form
    {
        private enum enLoadMode { All, Patient };
        private enLoadMode _Mode = enLoadMode.All;
        private int? _PatientID = null;

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
            if (_Mode == enLoadMode.All)
                await _RefreshData();
            else
                await _LoadPatientAppointments();
        }

        public void LoadForPatient(int patientID)
        {
            _Mode = enLoadMode.Patient;

            _PatientID = patientID;
        }

        private async void btnAddAppointment_Click(object sender, EventArgs e)
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
            cbDate.Visible = cbManageAppointments.SelectedItem.Equals("Dates");

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

        private async void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDate.SelectedItem)
            {
                case "Today":
                    _AppointmentsFilter = await clsAppointment.GetTodaysAsync();
                    break;

                case "Tomorrow":
                    _AppointmentsFilter = await clsAppointment.GetTomorrowsAsync();
                    break;

                case "This Week":
                    _AppointmentsFilter = await clsAppointment.GetThisWeekAppointmentsAsync();
                    break;

                case "Next Week":
                    _AppointmentsFilter = await clsAppointment.GetNextWeekAppointmeentsAsync();
                    break;

                case "This Month":
                    _AppointmentsFilter = await clsAppointment.GetThisMonthAppointmentsAsync();
                    break;

                case "Next Month":
                    _AppointmentsFilter = await clsAppointment.GetNextMonthAppointmentsAsync();
                    break;
                default:
                    _AppointmentsFilter = _AppointmentsList;
                    break;
            }

            dgvManageAppointments.DataSource = _AppointmentsFilter;
            lblRecordCount.Text = dgvManageAppointments.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task _LoadPatientAppointments()
        {
            int patientID = (int)_PatientID;

            await _LoadPatients();

            _AppointmentsList = await clsAppointment.GetByPatientAsync(patientID);

            cbManageAppointments.SelectedItem = "Patient";

            PatientDTO patient = await clsPatient.FindAsync(patientID);
            cbPatients.SelectedItem = string.Join(" ", patient.FirstName, patient.LastName);

            cbManageAppointments.Enabled = false;
            cbPatients.Enabled = false;
            btnAddAppointment.Enabled = false;
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID = (int)dgvManageAppointments.CurrentRow.Cells[0].Value;

            frmAddEditAppointment frm = new frmAddEditAppointment(appointmentID);
            frm.ShowDialog();
            await _RefreshData();
        }

        private void cmsManageUsers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string currentStatusCaption = dgvManageAppointments.CurrentRow.Cells[4].Value.ToString();

            enAppointmentStatus status;

            switch (currentStatusCaption)
            {
                case "Pending":
                    status = enAppointmentStatus.Pending;
                    break;

                case "Confirmed":
                    status = enAppointmentStatus.Confirmed;
                    break;

                case "Completed":
                    status = enAppointmentStatus.Completed;
                    break;

                case "Cancelled":
                    status = enAppointmentStatus.Cancelled;
                    break;

                case "Rescheduled":
                    status = enAppointmentStatus.Rescheduled;
                    break;

                case "NoShow":
                    status = enAppointmentStatus.NoShow;
                    break;

                default:
                    status = enAppointmentStatus.Pending;
                    break;
            }

            updateToolStripMenuItem.Enabled = status == enAppointmentStatus.Pending ||
                                              status == enAppointmentStatus.Confirmed ||
                                              status == enAppointmentStatus.Rescheduled;

            cancelToolStripMenuItem.Enabled = status == enAppointmentStatus.Pending &&
                                              status == enAppointmentStatus.Confirmed &&
                                              status == enAppointmentStatus.Rescheduled;

            confirmToolStripMenuItem.Enabled = status == enAppointmentStatus.Pending;

            noShowStripMenuItem.Enabled = status == enAppointmentStatus.Confirmed ||
                                          status == enAppointmentStatus.Rescheduled;
        }

        private async void confirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID = (int)dgvManageAppointments.CurrentRow.Cells[0].Value;
            AppointmentDTO appointmentDTO = await clsAppointment.FindAsync(appointmentID);

            clsAppointment appointment = new clsAppointment(appointmentDTO);

            if (!appointment.Status.Equals(enAppointmentStatus.Pending))
            {
                MessageBox.Show("Appointment already confirmed", "Appointment Confirmed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            appointment.Status = enAppointmentStatus.Confirmed;

            if (!appointment.Save())
            {
                MessageBox.Show("Appointment confirmation failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            await _RefreshData();
        }

        private async void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID = (int)dgvManageAppointments.CurrentRow.Cells[0].Value;
            AppointmentDTO appointmentDTO = await clsAppointment.FindAsync(appointmentID);

            clsAppointment appointment = new clsAppointment(appointmentDTO);

            if (appointment.Status.Equals(enAppointmentStatus.Completed))
            {
                MessageBox.Show("Appointment completed you can't cancel it!", "Appointment Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (appointment.Status.Equals(enAppointmentStatus.Cancelled))
            {
                MessageBox.Show("Appointment already cancelled!", "Appointment Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (appointment.Status.Equals(enAppointmentStatus.NoShow))
            {
                MessageBox.Show("Patient did not show to his appointment, you can't cancel this appointment!",
                    "Patient Did Not Show",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            appointment.Status = enAppointmentStatus.Cancelled;

            if (!appointment.Save())
            {
                MessageBox.Show("Appointment cancelling failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            await _RefreshData();
        }

        private async void noShowStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID = (int)dgvManageAppointments.CurrentRow.Cells[0].Value;
            AppointmentDTO appointmentDTO = await clsAppointment.FindAsync(appointmentID);

            clsAppointment appointment = new clsAppointment(appointmentDTO);

            if (appointment.Date >  DateTime.Now)
            {
                MessageBox.Show("Appointment Date is still in the future!", "Upcoming Appointment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            appointment.Status = enAppointmentStatus.NoShow;

            if (!appointment.Save())
            {
                MessageBox.Show("Appointment status changing failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await _RefreshData();
        }
    }
}
