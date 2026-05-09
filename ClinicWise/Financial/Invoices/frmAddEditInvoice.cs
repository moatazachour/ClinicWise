using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.InvoiceItems;
using ClinicWise.Contracts.Invoices;
using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Financial.Invoices
{
    public partial class frmAddEditInvoice : Form
    {
        private int _AppointmentID;
        private clsInvoice _Invoice;
        private List<InvoiceItemDTO> _InvoiceItems;

        public frmAddEditInvoice(int appointmentID)
        {
            InitializeComponent();

            _AppointmentID = appointmentID;
        }

        private async void frmAddEditInvoice_Load(object sender, EventArgs e)
        {
            await _LoadInformations();
        }

        private async Task _LoadInformations()
        {
            InvoiceDTO invoice = await clsInvoice.FindDraftedByAppointmentIdAsync(_AppointmentID);

            if (invoice == null)
                return;

            _Invoice = new clsInvoice(invoice);

            lblInvoiceNumber.Text = _Invoice.InvoiceNumber;
            lblAppointmentID.Text = _Invoice.AppointmentID.ToString();
            lblPatient.Text = await _GetPatientFullName();
            lblDoctor.Text = await _GetDoctorFullLabelName();
            lblSubTotal.Text = $"{_Invoice.SubTotal} TND";
            lblTotalAmount.Text = $"{_Invoice.TotalAmount} TND";
            await _LoadInvoiceItems();
        }

        private async Task _LoadInvoiceItems()
        {
            _InvoiceItems = await clsInvoiceItem.GetAllByInvoiceAsync(_Invoice.InvoiceID);
            dgvInvoiceItems.DataSource = _InvoiceItems;

            dgvInvoiceItems.Columns["InvoiceID"].Visible = false;
            dgvInvoiceItems.Columns["VisitFeeID"].Visible = false;
        }

        private async Task<string> _GetDoctorFullLabelName()
        {
            AppointmentDTO appointmentDTO = await clsAppointment.FindAsync(_Invoice.AppointmentID);
            DoctorDTO doctorDTO = await clsDoctor.FindAsync(appointmentDTO.DoctorID);
            clsSpecialization specialization = await clsSpecialization.FindAsync(doctorDTO.SpecializationID);
            string doctorFullName = doctorDTO.FullName;
            string specializationName = specialization.Name;

            return string.Format("{0} - {1}", doctorFullName, specializationName);
        }

        private async Task<string> _GetPatientFullName()
        {
            PatientDTO patientDTO = await clsPatient.FindAsync(_Invoice.PatientID);
            return patientDTO.FullName;
        }
    }
}
