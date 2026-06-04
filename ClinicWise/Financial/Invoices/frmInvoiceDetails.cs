using System;
using System.Windows.Forms;

namespace ClinicWise.Financial.Invoices
{
    public partial class frmInvoiceDetails : Form
    {
        private int _InvocieID;

        public frmInvoiceDetails(int invoiceID)
        {
            InitializeComponent();

            _InvocieID = invoiceID;
        }

        private async void frmInvoiceDetails_Load(object sender, EventArgs e)
        {
            await ctrlInvoiceCard1.LoadForDetails(_InvocieID);  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
