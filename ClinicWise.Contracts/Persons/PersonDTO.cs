using System;

namespace ClinicWise.Contracts.Persons
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string GenderCaption { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public int CreatedBy { get; set; }
    }
}
