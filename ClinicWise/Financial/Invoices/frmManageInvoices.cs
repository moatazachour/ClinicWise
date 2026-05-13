using ClinicWise.Business;
using ClinicWise.Contracts.Invoices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Invoices
{
    public partial class frmManageInvoices : Form
    {
        private List<InvoiceViewDTO> _InvoicesList;

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
            dgvManageInvoices.Columns["PatientID"].Visible = false;
            dgvManageInvoices.Columns["Status"].Visible = false;

            lblRecordCount.Text = dgvManageInvoices.RowCount.ToString();
        }
    }
}
