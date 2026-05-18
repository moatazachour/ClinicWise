using System;
using System.Windows.Forms;

namespace ClinicWise.Financial.Payments
{
    public partial class frmManagePayments : Form
    {
        public frmManagePayments()
        {
            InitializeComponent();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            frmAddEditPayment frm = new frmAddEditPayment(-1);
            frm.ShowDialog();
        }
    }
}
