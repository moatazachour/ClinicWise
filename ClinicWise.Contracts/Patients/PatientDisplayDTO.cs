using System;

namespace ClinicWise.Contracts.Patients
{
    public class PatientDisplayDTO
    {
        public int PatientID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string GenderCaption { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? GuardianID { get; set; }
    }
}
