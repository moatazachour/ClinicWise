using System;
using System.Windows.Forms;

namespace ClinicWise.Users
{
    public partial class frmUserInfo : Form
    {
        private int _UserID;

        public frmUserInfo(int userID)
        {
            InitializeComponent();

            _UserID = userID;
        }

        private async void frmUserInfo_Load(object sender, EventArgs e)
        {
            await ctrlUserCard1.LoadDataAsync(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
