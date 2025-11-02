namespace ClinicWise.Business
{
    public class clsUser
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }

        public clsUser()
        {
            UserID = -1;
            Username = null;
            Email = null;
            Password = null;
            RoleID = -1;

            Mode = enMode.AddNew;
        }

        public clsUser(int userID, string username, string email, string password, int roleID)
        {
            UserID = userID;
            Username = username;
            Email = email;
            Password = password;
            RoleID = roleID;

            Mode = enMode.Update;
        }
    }
}
