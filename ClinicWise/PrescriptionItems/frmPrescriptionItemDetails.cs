using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.PrescriptionItems
{
    public partial class frmPrescriptionItemDetails : Form
    {
        private int _PrescriptionItemID;

        public frmPrescriptionItemDetails(int prescriptionItemID)
        {
            _PrescriptionItemID = prescriptionItemID;

            InitializeComponent();
        }

        private async void frmPrescriptionItemDetails_Load(object sender, EventArgs e)
        {
            await ctrlPrescriptionItemCard1.LoadPrescriptionItemData(_PrescriptionItemID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
