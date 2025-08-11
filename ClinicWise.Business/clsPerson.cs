using ClinicWise.DataAccess;
using System;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsPerson
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;
        
        public enum enPersonType { Doctor, Patient }

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CreatedByUserID { get; set; }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = null;
            FirstName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Phone = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        public clsPerson(
            int personID, string nationalNo, string firstName, string lastName, DateTime dateOfBirth, 
            byte gender, string phone, string email, string address, int createdByUserID)
        {
            PersonID = personID;
            NationalNo = nationalNo; 
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Phone = phone;
            Email = email;
            Address = address;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }


        private bool _AddNew()
        {
            PersonID = clsPersonData.AddNewPerson(NationalNo, FirstName, LastName, DateOfBirth,
            Gender, Phone, Email, Address, CreatedByUserID);

            return PersonID != -1;
        }

        private bool _Update()
        {
            return clsPersonData.Update(
                PersonID,
                NationalNo,
                FirstName,
                LastName,
                DateOfBirth,
                Gender,
                Phone,
                Email,
                Address,
                CreatedByUserID);
        }

        public virtual bool Save()
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
            }

            return true;
        }
    }
}
