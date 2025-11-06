using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Doctors;
using ClinicWise.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);

            frm.ShowDialog();
        }

        //private List<DoctorDisplayDTO> _DoctorList;

        //private List<DoctorDisplayDTO> _DoctorFilter;

        //private async Task _RefreshData()
        //{
        //    cbManageUsers.SelectedItem = "None";

        //    _DoctorList = await clsDoctor.GetAllDoctorsAsync();

        //    dgvManageDoctors.DataSource = _DoctorList;

        //    lblRecordCount.Text = dgvManageDoctors.RowCount.ToString();

        //    mtxtFilter.Visible = false;
        //}

        //private async void frmManageDoctors_Load(object sender, EventArgs e)
        //{
        //    await _RefreshData();
        //}


        //private void cbManageDoctors_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    mtxtFilter.Visible = (cbManageDoctors.Text != "None");

        //    if (mtxtFilter.Visible)
        //    {
        //        mtxtFilter.Mask = "";
        //        mtxtFilter.Text = "";
        //        mtxtFilter.Focus();
        //    }

        //    if (cbManageDoctors.Text == "None")
        //        dgvManageDoctors.DataSource = _DoctorList;
        //}

        //private void mtxtFilter_TextChanged(object sender, EventArgs e)
        //{
        //    switch (cbManageDoctors.Text)
        //    {
        //        case "DoctorID":
        //            if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
        //                _DoctorFilter = _DoctorList;
        //            else
        //                _DoctorFilter = _DoctorList.Where(d => d.DoctorID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
        //            break;

        //        case "Fullname":
        //            _DoctorFilter = _DoctorList.Where(d => d.FullName.ToLower().Contains(mtxtFilter.Text.ToLower().Trim())).ToList();
        //            break;

        //        case "Gender":
        //            _DoctorFilter = _DoctorList.Where(d => d.GenderCaption.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
        //            break;

        //        case "Phone":
        //            _DoctorFilter = _DoctorList.Where(d => d.Phone.StartsWith(mtxtFilter.Text.Trim())).ToList();
        //            break;

        //        case "Email":
        //            _DoctorFilter = _DoctorList.Where(d => d.Email.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
        //            break;

        //        case "Specialization":
        //            _DoctorFilter = _DoctorList.Where(d => d.Specialization.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
        //            break;

        //        case "Address":
        //            _DoctorFilter = _DoctorList.Where(d => d.Address.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
        //            break;

        //        default:
        //            _DoctorFilter = _DoctorList;
        //            break;
        //    }

        //    dgvManageDoctors.DataSource = _DoctorFilter;
        //    lblRecordCount.Text = dgvManageDoctors.RowCount.ToString();
        //}

        //private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (cbManageDoctors.Text == "DoctorID")
        //        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        //}
    }
}
