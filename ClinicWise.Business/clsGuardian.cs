using ClinicWise.Contracts.Guardians;
using ClinicWise.Contracts.Patients;
using ClinicWise.DataAccess;
using System;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsGuardian : clsPerson
    {
        public new enum enMode { AddNew, Update }
        public new enMode Mode = enMode.AddNew;

        public int GuardianID { get; set; }
        public int RelashionshipID { get; set; }

        public clsGuardian()
        {
            GuardianID = -1;
            RelashionshipID = -1;

            Mode = enMode.AddNew;
        }

        public clsGuardian(
            int guardianID, int relationshipID,
            int personID, string nationalNo,
            string firstName, string lastName,
            DateTime dateOfBirth, byte gender,
            string phone, string email,
            string address, string imagePath,
            int createdByUserID)
            : base(
                  personID,
                  nationalNo,
                  firstName,
                  lastName,
                  dateOfBirth,
                  gender,
                  phone,
                  email,
                  address,
                  imagePath,
                  createdByUserID)
        {
            GuardianID = guardianID;
            RelashionshipID = relationshipID;

            Mode = enMode.Update;
        }

        public clsGuardian(GuardianDTO guardianDto)
            : base(
                  guardianDto.PersonID,
                  guardianDto.NationalNo,
                  guardianDto.FirstName,
                  guardianDto.LastName,
                  guardianDto.DateOfBirth,
                  guardianDto.Gender,
                  guardianDto.Phone,
                  guardianDto.Email,
                  guardianDto.Address,
                  guardianDto.ImagePath,
                  guardianDto.CreatedByUserID)
        {
            GuardianID = guardianDto.GuardianID;
            RelashionshipID = guardianDto.RelationshipID;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            GuardianID = clsGuardianData.AddNew(PersonID, RelashionshipID);

            return GuardianID != -1;
        }

        private bool _Update()
        {
            return clsGuardianData.Update(GuardianID, RelashionshipID);
        }

        public override bool Save()
        {
            if (!base.Save())
                return false;

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

        public async static Task<GuardianDTO> FindAsync(int guardianID)
        {
            return await clsGuardianData.GetByID(guardianID);
        }

        public GuardianDTO ToDTO()
        {
            return new GuardianDTO(GuardianID, PersonID, NationalNo, FirstName, LastName,
                DateOfBirth, Gender, Phone, Email, Address, ImagePath, RelashionshipID, CreatedByUserID);
        }
    }
}
