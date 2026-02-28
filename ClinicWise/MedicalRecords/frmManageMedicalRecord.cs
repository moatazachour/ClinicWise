using ClinicWise.Business;
using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Medicaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.MedicalRecords
{
    public partial class frmManageMedicalRecord : Form
    {
        private List<MedicalRecordViewDTO> _MedicalRecordsList;
        private List<MedicalRecordViewDTO> _MedicalRecordsFilteredList;

        public frmManageMedicalRecord()
        {
            InitializeComponent();
        }

        private void btnAddMedicalRecord_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalRecord frm = new frmAddEditMedicalRecord(-1);
            frm.ShowDialog();
        }

        private async void frmManageMedicalRecord_Load(object sender, EventArgs e)
        {
            _LoadVisitTypesComboBox();
            await _LoadDataAsync();
        }

        private async Task _LoadDataAsync()
        {
            cbManageMedicalRecord.SelectedItem = "None";
            _MedicalRecordsList = await clsMedicalRecord.GetAllAsync();
            dgvManageMedicalRecords.DataSource = _MedicalRecordsList;
            lblRecordCount.Text = dgvManageMedicalRecords.RowCount.ToString();
        }

        private void _LoadVisitTypesComboBox()
        {
            foreach (enVisitType visitType in Enum.GetValues(typeof(enVisitType)))
            {
                cbVisitTypes.Items.Add(visitType);
            }
        }

        private void cbManageMedicalRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVisitTypes.Visible = cbManageMedicalRecord.SelectedItem.Equals("Visit Type");
            mtxtFilter.Visible = cbManageMedicalRecord.SelectedItem.Equals("Medical Record ID")
                || cbManageMedicalRecord.SelectedItem.Equals("Appointment ID");

            if (mtxtFilter.Visible)
            {
                mtxtFilter.Mask = "";
                mtxtFilter.Text = "";
                mtxtFilter.Focus();
            }

            if (cbManageMedicalRecord.SelectedItem.Equals("None"))
                dgvManageMedicalRecords.DataSource = _MedicalRecordsList;

            lblRecordCount.Text = dgvManageMedicalRecords.RowCount.ToString();
        }

        private void mtxtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (cbManageMedicalRecord.Text)
            {
                case "Medical Record ID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _MedicalRecordsFilteredList = _MedicalRecordsList;
                    else
                        _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.RecordID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Appointment ID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _MedicalRecordsFilteredList = _MedicalRecordsList;
                    else
                        _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.AppointmentID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;


                default:
                    _MedicalRecordsFilteredList = _MedicalRecordsList;
                    break;
            }

            dgvManageMedicalRecords.DataSource = _MedicalRecordsFilteredList;
            lblRecordCount.Text = dgvManageMedicalRecords.RowCount.ToString();
        }

        private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbManageMedicalRecord.Text == "Medical Record ID"
                || cbManageMedicalRecord.Text == "Appointment ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbVisitTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbVisitTypes.Text)
            {
                case "Consultation":
                    _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.VisitType.Equals("Consultation")).ToList();
                    break;

                case "FollowUp":
                    _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.VisitType.Equals("Follow Up")).ToList();
                    break;

                case "Emergency":
                    _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.VisitType.Equals("Emergency")).ToList();
                    break;

                case "RoutineCheck":
                    _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.VisitType.Equals("Routine Check")).ToList();
                break;

                case "Vaccination":
                    _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.VisitType.Equals("Vaccination")).ToList();
                    break;

                case "LabTest":
                    _MedicalRecordsFilteredList = _MedicalRecordsList
                            .Where(mr => mr.VisitType.Equals("Lab Test")).ToList();
                    break;

                default:
                    _MedicalRecordsFilteredList = _MedicalRecordsList;
                    break;
            }

            dgvManageMedicalRecords.DataSource = _MedicalRecordsFilteredList;
            lblRecordCount.Text = dgvManageMedicalRecords.RowCount.ToString();
        }

        private async void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalRecord frm = new frmAddEditMedicalRecord(-1);
            frm.ShowDialog();

            await _LoadDataAsync();

        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentMedicalRecordID = (int)dgvManageMedicalRecords.CurrentRow.Cells[0].Value;

            frmAddEditMedicalRecord frm = new frmAddEditMedicalRecord(currentMedicalRecordID);
            frm.ShowDialog();

            await _LoadDataAsync();
        }
    }
}
