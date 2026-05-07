alter procedure VisitFee_GetAll
as
begin
	set nocount on;

	SELECT 
		VisitFeeID,
		VisitTypeLabel,
		BaseAmount,
		EffectiveFrom,
		EffectiveTo,
		CreatedBy,
		IsActive
	FROM GetAllVisitFees_View;

end;