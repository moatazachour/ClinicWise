using ClinicWise.Business;
using ClinicWise.Contracts.Payments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Payments
{
    public partial class frmManagePayments : Form
    {
        private List<PaymentViewDTO> _PaymentsList;

        public frmManagePayments()
        {
            InitializeComponent();
        }

        private async void btnAddPayment_Click(object sender, EventArgs e)
        {
            frmAddEditPayment frm = new frmAddEditPayment(-1);
            frm.ShowDialog();

            await _LoadInformationsAsync();
        }

        private async void frmManagePayments_Load(object sender, EventArgs e)
        {
            await _LoadInformationsAsync();
        }

        private async Task _LoadInformationsAsync()
        {
            cbManagePayments.Text = "None";

            _PaymentsList = await clsPayment.GetAllAsync();
            dgvManagePayment.DataSource = _PaymentsList;

            dgvManagePayment.Columns["InvoiceID"].Visible = false;
            dgvManagePayment.Columns["Method"].Visible = false;
            dgvManagePayment.Columns["RecordedByUserID"].Visible = false;

            lblRecordCount.Text = _PaymentsList.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbManagePayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = cbManagePayments.Text != "None";
        }

        private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbManagePayments.Text == "Payment ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPayment frm = new frmAddEditPayment(-1);
            frm.ShowDialog();

            await _LoadInformationsAsync();
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedId = (int)dgvManagePayment.CurrentRow.Cells[0].Value;
            frmAddEditPayment frm = new frmAddEditPayment(selectedId);
            frm.ShowDialog();

            await _LoadInformationsAsync();
        }
    }
}
