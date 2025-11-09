using ClinicWise.Contracts.Roles;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsRole
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public int RoleID { get; set; }
        public string RoleName { get; set; }


        public clsRole()
        {
            RoleID = -1;
            RoleName = null;

            Mode = enMode.AddNew;
        }

        public clsRole(int roleID, string roleName)
        {
            RoleID = roleID;
            RoleName = roleName;

            Mode = enMode.AddNew;
        }
        
        public static async Task<List<RoleDTO>> GetAllAsync()
        {
            return await clsRoleData.GetAllAsync();
        }

        public static RoleDTO FindByRoleName(string roleName)
        {
            return clsRoleData.GetByRoleName(roleName);
        }

        public static async Task<RoleDTO> FindAsync(int  roleID)
        {
            return await clsRoleData.GetByIDAsync(roleID);
        }
    }
}
