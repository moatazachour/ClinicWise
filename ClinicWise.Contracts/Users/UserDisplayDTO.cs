namespace ClinicWise.Contracts.Users
{
    public class UserDisplayDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string IsActiveCaption { get; set; }
        public string CreatedBy { get; set; }

        public UserDisplayDTO(int userID, string username, string roleName, string isActiveCaption, string createdBy)
        {
            UserID = userID;
            Username = username;
            RoleName = roleName;
            IsActiveCaption = isActiveCaption;
            CreatedBy = createdBy;
        }
    }
}
