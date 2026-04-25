using ClinicWise.Contracts.MedicalRecords;
using System;

namespace ClinicWise.Contracts.VisitTypeFees
{
    public class VisitTypeFeeDTO
    {
        public int ID { get; set; }
        public enVisitType VisitType { get; set; }
        public decimal BaseAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedAt { get; set; }

        public VisitTypeFeeDTO(
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
        }

    }
}
