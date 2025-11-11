using ClinicWise.Business;
using ClinicWise.Contracts;
using ClinicWise.Contracts.Users;
using ClinicWise.Doctors;
using ClinicWise.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClinicWise.Users
{
    public partial class frmManageUsers : Form
    {
        private List<UserDisplayDTO> _UserList;
        private List<UserDisplayDTO> _UserFilter;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);

            frm.ShowDialog();
        }

        private async Task _RefreshData()
        {
            cbManageUsers.SelectedItem = "None";

            mtxtFilter.Visible = false;
            cbUserRoles.Visible = false;

            _UserList = await clsUser.GetAllAsync();

            dgvManageUsers.DataSource = _UserList;

            lblRecordCount.Text = _UserList.Count.ToString();
        }

        private async void frmManageUsers_Load(object sender, EventArgs e)
        {
            await _RefreshData();
        }

        private void cbManageUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtFilter.Visible = cbManageUsers.Text != "None" && cbManageUsers.Text != "Role";

            cbUserRoles.Visible = cbManageUsers.Text == "Role";

            if (mtxtFilter.Visible)
            {
                mtxtFilter.Mask = "";
                mtxtFilter.Text = "";
                mtxtFilter.Focus();
            }

            if (cbManageUsers.Text == "None")
                dgvManageUsers.DataSource = _UserList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mtxtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (cbManageUsers.Text)
            {
                case "UserID":
                    if (string.IsNullOrWhiteSpace(mtxtFilter.Text))
                        _UserFilter = _UserList;
                    else
                        _UserFilter = _UserList.Where(u => u.UserID == Convert.ToInt32(mtxtFilter.Text.Trim())).ToList();
                    break;

                case "Username":
                    _UserFilter = _UserList.Where(u => u.Username.ToLower().StartsWith(mtxtFilter.Text.ToLower().Trim())).ToList();
                    break;

                default:
                    _UserFilter = _UserList;
                    break;
            }

            dgvManageUsers.DataSource = _UserFilter;
            lblRecordCount.Text = dgvManageUsers.RowCount.ToString();
        }

        private void mtxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbManageUsers.Text == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbUserRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UserFilter = _UserList.Where(u => string.Equals(u.RoleName, cbUserRoles.Text)).ToList();

            dgvManageUsers.DataSource = _UserFilter;
            lblRecordCount.Text = dgvManageUsers.RowCount.ToString();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvManageUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvManageUsers.CurrentRow.Cells[0].Value;

            frmUserInfo frm = new frmUserInfo(userID);
            frm.ShowDialog();
        }
    }
}
