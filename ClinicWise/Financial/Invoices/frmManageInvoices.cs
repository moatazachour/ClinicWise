using ClinicWise.Business;
using ClinicWise.Contracts.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClinicWise.Business.clsAppointment;

namespace ClinicWise.Financial.Invoices
{
    public partial class frmManageInvoices : Form
    {
        private List<InvoiceViewDTO> _InvoicesList;
        private List<InvoiceViewDTO> _InvoicesFilter;

        public frmManageInvoices()
        {
            InitializeComponent();
        }

        private async void frmManageInvoices_Load(object sender, EventArgs e)
        {
            await _LoadData();
        }

        private async Task _LoadData()
        {
            cbManageInvoices.SelectedItem = "None";
            _InvoicesList = await clsInvoice.GetAllAsync();
            
            dgvManageInvoices.DataSource = _InvoicesList;
            
            dgvManageInvoices.Columns["OutstandingBalance"].DefaultCellStyle.NullValue = "N/A";
            dgvManageInvoices.Columns["IssuedBy"].DefaultCellStyle.NullValue = "N/A";
            dgvManageInvoices.Columns["Status"].Visible = false;

            lblRecordCount.Text = dgvManageInvoices.RowCount.ToString();
        }

        private void cbManageInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = !cbManageInvoices.SelectedItem.Equals("None")
                && !cbManageInvoices.SelectedItem.Equals("Status");
            cbInvoiceStatus.Visible = cbManageInvoices.SelectedItem.Equals("Status");
            dgvManageInvoices.DataSource = _InvoicesList;
            lblRecordCount.Text = dgvManageInvoices.Rows.Count.ToString();
        }

        private void mtxtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (cbManageInvoices.Text)
            {
                case "Invoice ID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _InvoicesFilter = _InvoicesList;
                    else
                        _InvoicesFilter = _InvoicesList.Where(i => i.InvoiceID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Invoice Number":
                    _InvoicesFilter = _InvoicesList.Where(i => i.InvoiceNumber.ToLower().Contains(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                case "Appointment ID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _InvoicesFilter = _InvoicesList;
                    else
                        _InvoicesFilter = _InvoicesList.Where(i => i.AppointmentID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Patient ID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _InvoicesFilter = _InvoicesList;
                    else
                        _InvoicesFilter = _InvoicesList.Where(i => i.PatientID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Patient Name":
                    _InvoicesFilter = _InvoicesList.Where(i => i.PatientName.ToLower().Contains(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                default:
                    _InvoicesFilter = _InvoicesList;
                    break;
            }

            dgvManageInvoices.DataSource = _InvoicesFilter;
            lblRecordCount.Text = dgvManageInvoices.RowCount.ToString();
        }

        private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbManageInvoices.Text == "Invoice ID" ||
                cbManageInvoices.Text == "Appointment ID" ||
                cbManageInvoices.Text == "Patient ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbInvoiceStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _InvoicesFilter = _InvoicesList.Where(i => i.StatusLabel.Equals(cbInvoiceStatus.Text)).ToList();
            dgvManageInvoices.DataSource = _InvoicesFilter;
            lblRecordCount.Text = dgvManageInvoices.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
