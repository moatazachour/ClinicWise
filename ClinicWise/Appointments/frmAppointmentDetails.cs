using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Appointments
{
    public partial class frmAppointmentDetails : Form
    {
        private int _AppointmentID;

        public frmAppointmentDetails(int appointmentID)
        {
            InitializeComponent();

            _AppointmentID = appointmentID;
        }

        private async void frmAppointmentDetails_Load(object sender, EventArgs e)
        {
            await ctrlAppointmentDetails1.LoadAppointmentInformations(_AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
