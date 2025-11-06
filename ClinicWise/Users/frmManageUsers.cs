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

        private void _RefreshData()
        {
            cbManageUsers.SelectedItem = "None";

            mtxtFilter.Visible = false;
            cbUserRoles.Visible = false;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void cbManageUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = cbManageUsers.Text != "None" && cbManageUsers.Text != "Role";

            cbUserRoles.Visible = cbManageUsers.Text == "Role";
        }
    }
}
