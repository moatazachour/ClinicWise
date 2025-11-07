using ClinicWise.Contracts.Users;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsUser
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public enum enUserTypes { Admin, Doctor }
        public enUserTypes UserType;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            Username = null;
            Password = null;
            RoleID = -1;

            Mode = enMode.AddNew;
        }

        public clsUser(int userID, int personID, string username, string password, int roleID, bool isActive, int createdByUserID)
        {
            UserID = userID;
            PersonID = personID;
            Username = username;
            Password = password;
            RoleID = roleID;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            bool isTheUserADoctor = clsDoctor.ExistsForPerson(PersonID);

            if (isTheUserADoctor)
                RoleID = clsRole.FindByRoleName("Doctor").RoleID;
            else
                RoleID = clsRole.FindByRoleName("Administrator").RoleID;

            UserID = clsUserData.AddNew(
                PersonID, Username, Password, RoleID, IsActive, CreatedByUserID);

            return UserID != -1;
        }

        private bool _Update()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        public static async Task<bool> IsPersonAssignedToUserAccountAsync(int personID)
        {
            return await clsUserData.IsPersonAssignedToUserAccountAsync(personID);
        }

        public static async Task<List<UserDisplayDTO>> GetAll()
        {
            return await clsUserData.GetAll();
        }
    }
}
