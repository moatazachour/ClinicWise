using ClinicWise.Contracts.MedicalRecords;
using System;

namespace ClinicWise.Contracts.VisitTypeFees
{
    public class VisitTypeFeeViewDTO
    {
        public int ID { get; set; }
        public string VisitTypeLabel { get; set; }
        public decimal BaseAmount { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

        public VisitTypeFeeViewDTO(
            int iD,
            string visitTypeLabel,
            decimal baseAmount,
            DateTime effectiveFrom,
            DateTime? effectiveTo,
            string createdBy,
            bool isActive)
        {
            ID = iD;
            VisitTypeLabel = visitTypeLabel;
            BaseAmount = baseAmount;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
            CreatedBy = createdBy;
            IsActive = isActive;
        }
    }
}
