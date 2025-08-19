using System;

namespace ClinicWise.Contracts
{
    public class DoctorDisplayDTO
    {
        public int DoctorID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public string Specialization { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string GenderCaption { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
