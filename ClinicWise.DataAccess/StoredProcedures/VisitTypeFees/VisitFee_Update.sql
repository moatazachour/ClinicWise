create procedure VisitFee_Update
	@VisitFeeID int,
	@VisitType tinyint,
	@BaseAmount decimal(18,3),
	@EffectiveFrom datetime,
	@EffectiveTo datetime
as
begin

	UPDATE [dbo].[VisitFees]
	SET [VisitType] =@VisitType
      ,[BaseAmount] = @BaseAmount
      ,[EffectiveFrom] = @EffectiveFrom
      ,[EffectiveTo] = @EffectiveTo
	WHERE [VisitFeeID] = @VisitFeeID;

end;