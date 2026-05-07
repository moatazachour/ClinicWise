create procedure VisitFee_GetByID
	@VisitFeeID int
as
begin
	set nocount on;

	SELECT [VisitType]
      ,[BaseAmount]
      ,[EffectiveFrom]
      ,[EffectiveTo]
      ,[CreatedByUserID]
      ,[CreatedAt]
  FROM [dbo].[VisitFees]
  WHERE [VisitFeeID] = @VisitFeeID;

end;