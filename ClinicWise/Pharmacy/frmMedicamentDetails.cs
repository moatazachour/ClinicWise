using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Pharmacy
{
    public partial class frmMedicamentDetails : Form
    {
        private int _MedicamentID;

        public frmMedicamentDetails(int medicamentID)
        {
            _MedicamentID = medicamentID;

            InitializeComponent();
        }

        private async void frmMedicamentDetails_Load(object sender, EventArgs e)
        {
            await ctrlMedicamentCard1.LoadMedicament(_MedicamentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
