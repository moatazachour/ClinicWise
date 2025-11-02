using ClinicWise.Business;
using ClinicWise.Contracts.Persons;
using ClinicWise.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Persons
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(PersonDTO personDTO)
        {
            lblPersonID.Text = personDTO.PersonID.ToString();
            lblName.Text = string.Join(" ", personDTO.FirstName, personDTO.LastName);
            lblNationalNo.Text = personDTO.NationalNo;
            lblDateOfBirth.Text = personDTO.DateOfBirth.ToShortDateString();
            lblEmail.Text = personDTO.Email;
            lblGender.Text = personDTO.Gender == 0 ? "Male" : "Female";
            lblPhone.Text = personDTO.Phone;
            lblAddress.Text = personDTO.Address;
            lblCreatedBy.Text = personDTO.CreatedBy.ToString();
            pbPersonImage.ImageLocation = personDTO.ImagePath;
            
            if (personDTO?.ImagePath == null)
                pbPersonImage.Image = Resources.person_boy;
        }

        public async Task LoadPersonInfo(int personID)
        {
            PersonDTO personDTO = await clsPerson.FindAsync(personID);

            if (personDTO != null)
            {
                lblPersonID.Text = personDTO.PersonID.ToString();
                lblName.Text = string.Join(" ", personDTO.FirstName, personDTO.LastName);
                lblNationalNo.Text = personDTO.NationalNo;
                lblDateOfBirth.Text = personDTO.DateOfBirth.ToShortDateString();
                lblEmail.Text = personDTO.Email;
                lblGender.Text = personDTO.Gender == 0 ? "Male" : "Female";
                lblPhone.Text = personDTO.Phone;
                lblAddress.Text = personDTO.Address;
                lblCreatedBy.Text = personDTO.CreatedBy.ToString();
                pbPersonImage.ImageLocation = personDTO.ImagePath;
            }

            if (personDTO?.ImagePath == null)
                pbPersonImage.Image = Resources.person_boy;
        }

        public async Task LoadPersonInfo(string nationalNo)
        {
            PersonDTO personDTO = await clsPerson.FindAsync(nationalNo);

            if (personDTO != null)
            {
                lblPersonID.Text = personDTO.PersonID.ToString();
                lblName.Text = string.Join(" ", personDTO.FirstName, personDTO.LastName);
                lblNationalNo.Text = personDTO.NationalNo;
                lblDateOfBirth.Text = personDTO.DateOfBirth.ToShortDateString();
                lblEmail.Text = personDTO.Email;
                lblGender.Text = personDTO.Gender == 0 ? "Male" : "Female";
                lblPhone.Text = personDTO.Phone;
                lblAddress.Text = personDTO.Address;
                lblCreatedBy.Text = personDTO.CreatedBy.ToString();
                pbPersonImage.ImageLocation = personDTO.ImagePath;
            }

            if (personDTO?.ImagePath == null)
                pbPersonImage.Image = Resources.person_boy;
        }

    }
}
