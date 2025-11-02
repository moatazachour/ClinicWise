using ClinicWise.Contracts.Persons;
using System;

namespace ClinicWise.Contracts
{
    public class DoctorDTO
    {
        public int DoctorID { get; set; }
        public string NationalNo { get; set; }
        public int SpecializationID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public int CreatedByUserID { get; set; }

        public PersonDTO ToPersonDTO()
        {
            return new PersonDTO
            {
                PersonID = PersonID,
                FirstName = FirstName,
                LastName = LastName,
                NationalNo = NationalNo,
                DateOfBirth = DateOfBirth,
                Gender = Gender,
                Phone = Phone,
                Email = Email,
                Address = Address,
                ImagePath = ImagePath,
                CreatedBy = CreatedByUserID
            };
        }
    }
}
