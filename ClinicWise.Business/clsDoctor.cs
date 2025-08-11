using ClinicWise.DataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsDoctor : clsPerson
    {
        public new enum enMode { AddNew, Update }
        public new enMode Mode = enMode.AddNew;

        public int DoctorID { get; set; }
        public int SpecializationID { get; set; }

        public clsDoctor()
        {
            DoctorID = -1;
            SpecializationID = -1;

            Mode = enMode.AddNew;
        }

        public clsDoctor(
            int doctorID,
            string nationalNo,
            int specializationID,
            int personID,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            byte gender,
            string phone,
            string email,
            string address,
            int createdByUserID)
            : base(personID, nationalNo, firstName, lastName, dateOfBirth, gender, phone, email, address, createdByUserID)
        {
            DoctorID = doctorID;
            SpecializationID = specializationID;

            Mode = enMode.Update;
        }


        public static async Task<DataTable> GetAllDoctorsAsync()
        {
            return await clsDoctorData.GetAllDoctors();
        }

        private async Task<bool> _AddNewAsync()
        {
            DoctorID = await clsDoctorData.AddNewDoctorAsync(PersonID, SpecializationID);

            return DoctorID != -1;
        }

        public override async Task<bool> SaveAsync()
        {
            if (!await base.SaveAsync())
                return false;

            switch(Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    break;
                
                default:
                    break;
            }

            return false;
        }
    }
}
