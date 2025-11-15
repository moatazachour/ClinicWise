using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Guardians;
using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Patients
{
    public partial class frmPatientDetails : Form
    {
        private int _PatientID;

        public frmPatientDetails(int patientID)
        {
            _PatientID = patientID;

            InitializeComponent();
        }

        private async Task _LoadData()
        {
            PatientDTO patientDTO = await clsPatient.FindAsync(_PatientID);
            clsPatient patient = new clsPatient(patientDTO);

            ctrlPersonCard1.LoadPersonInfo(patientDTO.ToPersonDTO());
            lblPatient.Text = _PatientID.ToString();

            GuardianDTO guardianDTO = await patient.GetGuardianInfo();
            if (guardianDTO != null)
            {
                clsGuardian guardian = new clsGuardian(guardianDTO);

                lblGuardianID.Text = guardianDTO.GuardianID.ToString();
                lblNationalNo.Text = guardianDTO.NationalNo;
                lblPhone.Text = guardianDTO.Phone;
                lblRelationship.Text = await guardian.GetRelationshipNameAsync();
            }
            else
            {
                gbGuardianInfo.Visible = false;
            }
        }

        private async void frmPatientDetails_Load(object sender, EventArgs e)
        {
            await _LoadData();
        }

        private void llEditPatient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient(_PatientID);

            frm.ShowDialog();
        }
    }
}
