using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.VisitTypeFees;
using ClinicWise.DataAccess;
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
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedAt { get; set; }

        public clsVisitTypeFee()
        {
            ID = -1;
            VisitType = enVisitType.Consultation;
            BaseAmount = 0;
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
            DateTime effectiveFrom, 
            DateTime? effectiveTo, 
            int createdByUserID, 
            DateTime createdAt)
        {
            ID = iD;
            VisitType = visitType;
            BaseAmount = baseAmount;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
            CreatedByUserID = createdByUserID;
            CreatedAt = createdAt;

            Mode = enMode.Update;
        }

        public clsVisitTypeFee(VisitTypeFeeDTO visitTypeDTO)
        {
            ID = visitTypeDTO.ID;
            VisitType = visitTypeDTO.VisitType;
            BaseAmount = visitTypeDTO.BaseAmount;
            EffectiveFrom = visitTypeDTO.EffectiveFrom;
            EffectiveTo = visitTypeDTO.EffectiveTo;
            CreatedByUserID = visitTypeDTO.CreatedByUserID;
            CreatedAt = visitTypeDTO.CreatedAt;

            Mode = enMode.Update;
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

        private bool _Update()
        {
            return clsVisitTypeFeeData.Update(ID, (byte)VisitType, BaseAmount, EffectiveFrom, EffectiveTo);
        }

        private bool _AddNew()
        {
            CreatedAt = DateTime.Now;
            this.ID = clsVisitTypeFeeData.AddNew((byte)VisitType, BaseAmount, EffectiveFrom, EffectiveTo, CreatedByUserID, CreatedAt);

            return this.ID != -1;
        }
        
        public static async Task<VisitTypeFeeDTO> FindAsync(int visitFeeID)
        {
            return await clsVisitTypeFeeData.GetByIDAsync(visitFeeID);
        }

        public static async Task<List<VisitTypeFeeViewDTO>> GetAllAsync()
        {
            return await clsVisitTypeFeeData.GetAllAsync();
        }
    }
}
