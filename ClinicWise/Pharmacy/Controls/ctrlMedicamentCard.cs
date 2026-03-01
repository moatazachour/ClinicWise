using ClinicWise.Business;
using ClinicWise.Contracts.Medicaments;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Pharmacy.Controls
{
    public partial class ctrlMedicamentCard : UserControl
    {
        public ctrlMedicamentCard()
        {
            InitializeComponent();
        }

        public async Task LoadMedicament(int medicamentID)
        {
            MedicamentDTO medicament = await clsMedicament.FindAsync(medicamentID);

            if (medicament == null)
                return;

            lblMedicamentID.Text = medicamentID.ToString();
            lblName.Text = medicament.Name;
            lblBrand.Text = medicament.Brand;
            lblDosageForm.Text = medicament.DosageForm.ToString();
        }
    }
}
