using System;

namespace ClinicWise.Contracts.Guardians
{
    public class GuardianDTO
    {
        public int GuardianID { get; set; }
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
        public int RelationshipID { get; set; }
        public int CreatedByUserID { get; set; }

        public GuardianDTO(
            int guardianID,
            int personID,
            string nationalNo,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            byte gender,
            string phone,
            string email,
            string address,
            string imagePath,
            int relationshipID,
            int createdByUserID)
        {
            GuardianID = guardianID;
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
            RelationshipID = relationshipID;
            CreatedByUserID = createdByUserID;
        }
    }
}
