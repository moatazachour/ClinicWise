using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.VisitTypeFees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsVisitTypeFee
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;

        public int ID { get; set; }
        public enVisitType VisitType { get; set; }
        public decimal BaseAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedAt { get; set; }

        public clsVisitTypeFee()
        {
            ID = -1;
            VisitType = enVisitType.Consultation;
            BaseAmount = 0;
            IsActive = false;
            EffectiveFrom = DateTime.Today;
            EffectiveTo = null;
            CreatedByUserID = -1;
            CreatedAt = DateTime.Now;

            Mode = enMode.AddNew;
        }

        public clsVisitTypeFee(
            int iD, 
            enVisitType visitType, 
            decimal baseAmount, 
            bool isActive, 
            DateTime effectiveFrom, 
            DateTime effectiveTo, 
            int createdByUserID, 
            DateTime createdAt)
        {
            ID = iD;
            VisitType = visitType;
            BaseAmount = baseAmount;
            IsActive = isActive;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
            CreatedByUserID = createdByUserID;
            CreatedAt = createdAt;

            Mode = enMode.Update;
        }

        public async Task<bool> Save()
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

        private bool _Update()
        {
            throw new NotImplementedException();
        }

        private bool _AddNew()
        {
            throw new NotImplementedException();
        }
        
        public async Task<VisitTypeFeeDTO> FindAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VisitTypeFeeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
