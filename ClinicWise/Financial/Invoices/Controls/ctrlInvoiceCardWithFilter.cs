using ClinicWise.Business;
using ClinicWise.Contracts.Invoices;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Invoices.Controls
{
    public partial class ctrlInvoiceCardWithFilter : UserControl
    {
        public clsInvoice SelectedInvoice;

        public ctrlInvoiceCardWithFilter()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string filterValue = txtFilter.Text;

            if (cbFilterBy.Text == "Invoice Number")
                await ctrlInvoiceCard1.LoadInformationsByInvoiceNumber(filterValue);
            else
                await ctrlInvoiceCard1.LoadInformations(Convert.ToInt32(filterValue));

            SelectedInvoice = ctrlInvoiceCard1.SelectedInvoice;
        }

        public async Task LoadAsync(int invoiceId)
        {
            InvoiceDTO invoiceDTO = await clsInvoice.FindAsync(invoiceId);
            SelectedInvoice = new clsInvoice(invoiceDTO);
            await ctrlInvoiceCard1.LoadInformations(SelectedInvoice.InvoiceID);
            cbFilterBy.Text = "Invoice Number";
            txtFilter.Text = SelectedInvoice.InvoiceNumber;
            gbFilter.Enabled = false;
        }

        private void ctrlInvoiceCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.Text = "Invoice Number";
            txtFilter.Focus();
        }
    }
}
