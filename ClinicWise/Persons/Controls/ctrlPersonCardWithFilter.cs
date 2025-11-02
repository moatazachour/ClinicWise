using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Persons;
using ClinicWise.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Persons
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private int _PersonID;
        private string _NationalNo;
        private clsPerson _Person;

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }

        public string NationalNo
        {
            get
            {
                return _NationalNo;
            }
        }

        public clsPerson Person
        {
            get
            {
                return _Person;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
            {
                if (int.TryParse(txtFilter.Text, out int personID))
                {
                    _PersonID = personID;
                    await ctrlPersonCard1.LoadPersonInfo(_PersonID);
                }
                else
                {
                    MessageBox.Show("You should enter an integer", "Error");
                }
            }
            if (cbFilterBy.Text == "National No")
            {
                _NationalNo = txtFilter.Text;

                await ctrlPersonCard1.LoadPersonInfo(_NationalNo);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Add Doctor", 
                "You want to add a doctor?",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmAddEditDoctor frm = new frmAddEditDoctor(-1);

                frm.DataBack += DoctorAdded;

                frm.ShowDialog();
            }
            else
            {
                frmAddEditPerson frm = new frmAddEditPerson(-1);

                frm.DataBack += PersonAdded;

                frm.ShowDialog();
            }
        }

        private async void DoctorAdded(int doctorID)
        {
            DoctorDTO doctor = await clsDoctor.FindAsync(doctorID);

            _PersonID = doctor.PersonID;

            await ctrlPersonCard1.LoadPersonInfo(_PersonID);

            cbFilterBy.Text = "National No";
            txtFilter.Text = doctor.NationalNo;
        }

        private async void PersonAdded(int personID)
        {
            PersonDTO person = await clsPerson.FindAsync(personID);

            _PersonID = personID;

            await ctrlPersonCard1.LoadPersonInfo(_PersonID);

            cbFilterBy.Text = "National No";
            txtFilter.Text = person.NationalNo;
        }
    }
}
