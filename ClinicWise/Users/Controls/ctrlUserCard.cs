using ClinicWise.Business;
using ClinicWise.Contracts.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicWise.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private UserDTO _User;

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public async Task LoadDataAsync(int userID)
        {
            _User = await clsUser.FindAsync(userID);

            await ctrlPersonCard1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = userID.ToString();
            lblUsername.Text = _User.Username;
            lblStatus.Text = _User.IsActive ? "Active" : "Inactive";
            lblRole.Text = await clsUser.GetRoleName(_User.RoleID);
        }
    }
}
