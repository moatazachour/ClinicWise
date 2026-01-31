using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.DataAccess;
using System;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsMedicalRecord
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public enum enVisitType
        {
            Consultation = 1, FollowUp = 2, Emergency = 3,
            RoutineCheck = 4, Vaccination = 5, LabTest = 6
        }

        public int RecordID { get; set; }
        public int AppointmentID { get; set; }
        public enVisitType VisitType { get; set; }
        public string DescriptionOfVisit { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }

        public clsMedicalRecord()
        {
            RecordID = -1;
            AppointmentID = -1;
            VisitType = enVisitType.Consultation;
            DescriptionOfVisit = null;
            Diagnosis = null;
            AdditionalNotes = null;

            Mode = enMode.AddNew;
        }

        public clsMedicalRecord(
            int recordID, 
            int appointmentID, 
            enVisitType visitType, 
            string descriptionOfVisit, 
            string diagnosis, 
            string additionalNotes)
        {
            RecordID = recordID;
            AppointmentID = appointmentID;
            VisitType = visitType;
            DescriptionOfVisit = descriptionOfVisit;
            Diagnosis = diagnosis;
            AdditionalNotes = additionalNotes;

            Mode = enMode.Update;
        }


        public static async Task<MedicalRecordDTO> FindByAppointmentID(int appointmentID)
        {
            return await clsMedicalRecordData.GetByAppointmentID(appointmentID);
        }

        private bool _AddNew()
        {
            RecordID = clsMedicalRecordData.AddNew(AppointmentID, (byte)VisitType, DescriptionOfVisit,
                                                   Diagnosis, AdditionalNotes);

            return RecordID != -1;
        }

        private bool _Update()
        {
            return clsMedicalRecordData.Update(RecordID, (byte)VisitType, DescriptionOfVisit,
                                               Diagnosis, AdditionalNotes);
        }

        public bool Save()
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

                default:
                    return false;
            }
        }

            
    }
}
