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
    }
}
