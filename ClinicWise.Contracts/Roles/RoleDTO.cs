namespace ClinicWise.Contracts.Roles
{
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public RoleDTO(int roleID, string roleName)
        {
            RoleID = roleID;
            RoleName = roleName;
        }
    }
}
