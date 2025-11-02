using ClinicWise.Contracts.Persons;
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
        public string ImagePath { get; set; }
        public int CreatedByUserID { get; set; }
        public int? DeletedByUserID { get; set; }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = null;
            FirstName = null;
            LastName = null;
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Phone = string.Empty;
            Email = null;
            Address = null;
            CreatedByUserID = -1;
            ImagePath = null;

            Mode = enMode.AddNew;
        }

        public clsPerson(
            int personID, string nationalNo, string firstName, string lastName, DateTime dateOfBirth, 
            byte gender, string phone, string email, string address, string imagePath, int createdByUserID)
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
            ImagePath = imagePath;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        public clsPerson(PersonDTO personDTO)
        {
            PersonID = personDTO.PersonID;
            NationalNo = personDTO.NationalNo;
            FirstName = personDTO.FirstName;
            LastName = personDTO.LastName;
            DateOfBirth = personDTO.DateOfBirth;
            Gender = personDTO.Gender;
            Phone = personDTO.Phone;
            Email = personDTO.Email;
            Address = personDTO.Address;
            ImagePath = personDTO.ImagePath;
            CreatedByUserID = personDTO.CreatedBy;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            PersonID = clsPersonData.AddNewPerson(NationalNo, FirstName, LastName, DateOfBirth,
            Gender, Phone, Email, Address, ImagePath, CreatedByUserID);

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
                ImagePath,
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

        public static async Task<PersonDTO> FindAsync(int personID)
        {
            return await clsPersonData.GetByID(personID);
        }

        public static async Task<PersonDTO> FindAsync(string nationalNo)
        {
            return await clsPersonData.GetByNationalNo(nationalNo);
        }

        public static bool IsExistByNationalNo(string nationalNo)
        {
            return clsPersonData.IsExistByNationalNo(nationalNo);
        }
    }
}
