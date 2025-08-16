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

        private bool _AddNewAsync()
        {
            DoctorID = clsDoctorData.AddNewDoctor(PersonID, SpecializationID);

            return DoctorID != -1;
        }

        public bool _Update()
        {
            return clsDoctorData.Update(
                DoctorID,
                SpecializationID);
        }

        public override bool Save()
        {
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static async Task<clsDoctor> FindAsync(int doctorID)
        {
            (
                bool isFound,
                string nationalNo,
                int specializationID,
                int personID,
                string firstName, string lastName,
                DateTime dateOfBirth,
                byte gender,
                string phone, string email, string address,
                int createdByUserID
            )
            = await clsDoctorData.GetDoctorByID(doctorID);

            if (!isFound)
                return null;

            return new clsDoctor(
                doctorID,
                nationalNo,
                specializationID,
                personID,
                firstName,
                lastName,
                dateOfBirth,
                gender,
                phone,
                email,
                address,
                createdByUserID);
        }

        public static bool Delete(int doctorID, int deletedByUserID)
        {
            return clsDoctorData.Delete(doctorID, deletedByUserID);
        }
    }
}
