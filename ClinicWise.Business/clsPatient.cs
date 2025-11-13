using ClinicWise.Contracts.Guardians;
using ClinicWise.Contracts.Patients;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsPatient : clsPerson
    {
        public new enum enMode { AddNew, Update }
        public new enMode Mode = enMode.AddNew;

        public int PatientID { get; set; }
        public int? GuardianID { get; set; }

        private GuardianDTO _GuardianInfo;

        public async Task<GuardianDTO> GetGuardianInfo()
        {
            if (_GuardianInfo == null && GuardianID != null)
            {
                _GuardianInfo = await clsGuardian.FindAsync(Convert.ToInt32(GuardianID));
            }

            return _GuardianInfo;
        }

        public clsPatient() 
        {
            PatientID = -1;
            GuardianID = -1;

            Mode = enMode.AddNew;
        }

        public clsPatient(
            int patientID, int? guardianID,
            int personID, string nationalNo, 
            string firstName, string lastName, 
            DateTime dateOfBirth, byte gender, 
            string phone, string email, 
            string address, string imagePath, 
            int createdByUserID) 
            : base(personID, nationalNo, firstName, lastName, dateOfBirth, gender, phone, email, address, imagePath, createdByUserID)
        {
            PatientID = patientID;
            GuardianID = guardianID;

            Mode = enMode.Update;
        }

        public clsPatient(PatientDTO patientDto)
            : base(patientDto.PersonID, 
                  patientDto.NationalNo, 
                  patientDto.FirstName,
                  patientDto.LastName,
                  patientDto.DateOfBirth,
                  patientDto.Gender,
                  patientDto.Phone,
                  patientDto.Email,
                  patientDto.Address,
                  patientDto.ImagePath,
                  patientDto.CreatedByUserID)
        {
            PatientID = patientDto.PatientID;
            GuardianID = patientDto.GuardianID;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            PatientID = clsPatientData.AddNew(PersonID, GuardianID);

            return PatientID != -1;
        }

        private bool _Update()
        {
            return clsPatientData.Update(PatientID, GuardianID);
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

        public new async static Task<PatientDTO> FindAsync(int patientID)
        {
            return await clsPatientData.GetByID(patientID);
        }

        public async static Task<List<PatientDisplayDTO>> GetAllAsync()
        {
            return await clsPatientData.GetAllAsync();
        }

        public static bool Delete(int patientID, int deletedByUserID)
        {
            return clsPatientData.Delete(patientID, deletedByUserID);
        }
    }
}
