alter view GetAllVisitFees_View
as
With VisitFeeData
As
(
	SELECT  vf.VisitFeeID
	  ,case vf.VisitType
		when 1 then 'Consultation'
		when 2 then 'Follow Up'
		when 3 then 'Emergency'
		when 4 then 'Routine Check'
		when 5 then 'Vaccination'
		when 6 then 'Lab Test'
		else 'Consultation'
	  end as VisitTypeLabel
      ,vf.BaseAmount
      ,vf.EffectiveFrom
      ,vf.EffectiveTo
      ,u.Username AS CreatedBy
      ,dbo.CheckIfFeeIsActive(vf.EffectiveFrom, vf.EffectiveTo) AS IsActive
  FROM VisitFees vf 
	INNER JOIN Users u
	ON vf.CreatedByUserID = u.UserID
)
SELECT 
    VisitFeeID,
    VisitTypeLabel,
    BaseAmount,
    EffectiveFrom,
    EffectiveTo,
    CreatedBy,
    IsActive
FROM VisitFeeData;