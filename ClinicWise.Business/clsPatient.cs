using ClinicWise.Contracts.Patients;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsPatient : clsPerson
    {
        public new enum enMode { AddNew, Update }
        public new enMode Mode = enMode.AddNew;

        public int PatientID { get; set; }
        public int? GuardianID { get; set; }

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

        private async Task<bool> _AddNewAsync()
        {
            PatientID = await DataAccess.clsPatientData.AddNewAsync(PersonID, GuardianID);

            return PatientID != -1;
        }

        private async Task<bool> _UpdateAsync()
        {
            return await DataAccess.clsPatientData.UpdateAsync(PatientID, GuardianID);
        }

        public async Task<bool> SaveAsync()
        {
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateAsync();

                default:
                    return false;
            }
        }

        public async Task<PatientDTO> FindAsync(int patientID)
        {
            return await clsPatientData.GetByID(PatientID);
        }

        public async static Task<List<PatientDisplayDTO>> GetAllAsync()
        {
            return await clsPatientData.GetAllAsync();
        }
    }
}
