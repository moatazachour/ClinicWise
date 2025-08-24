using ClinicWise.Contracts.Persons;
using System;
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
            lblName.Text = personDTO.FullName;
            lblNationalNo.Text = personDTO.NationalNo;
            lblDateOfBirth.Text = personDTO.DateOfBirth.ToShortDateString();
            lblEmail.Text = personDTO.Email;
            lblGender.Text = personDTO.GenderCaption;
            lblPhone.Text = personDTO.Phone;
            lblAddress.Text = personDTO.Address;
            lblCreatedBy.Text = personDTO.CreatedBy.ToString();
            pbPersonImage.ImageLocation = personDTO.ImagePath;
        }

    }
}
