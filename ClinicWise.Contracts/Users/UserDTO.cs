namespace ClinicWise.Contracts.Users
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public UserDTO(int userID, int personID, string username, string password, int roleID, bool isActive, int createdByUserID)
        {
            UserID = userID;
            PersonID = personID;
            Username = username;
            Password = password;
            RoleID = roleID;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
        }
    }
}
