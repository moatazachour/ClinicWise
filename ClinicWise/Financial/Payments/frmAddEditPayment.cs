using ClinicWise.Business;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Payments
{
    public partial class frmAddEditPayment : Form
    {
        private int _PaymentID;
        private clsInvoice _SelectedInvoice;

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public frmAddEditPayment(int paymentID)
        {
            InitializeComponent();

            _PaymentID = paymentID;
            _Mode = _PaymentID == -1 ? enMode.AddNew : enMode.Update;
        }

        public async Task LoadInvoice(int invoiceID)
        {
            await ctrlInvoiceCardWithFilter1.LoadAsync(invoiceID);
            _SelectedInvoice = ctrlInvoiceCardWithFilter1.SelectedInvoice;
        }
    }
}
