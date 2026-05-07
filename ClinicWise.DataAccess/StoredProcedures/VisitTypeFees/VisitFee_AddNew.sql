create procedure VisitFee_AddNew
	@VisitType tinyint,
	@BaseAmount decimal(18,3),
	@EffectiveFrom datetime,
	@EffectiveTo datetime,
	@CreatedByUserID int,
	@CreatedAt datetime,
    @VisitFeeID int output
as
begin

	set nocount on;

	INSERT INTO [dbo].[VisitFees]
           ([VisitType]
           ,[BaseAmount]
           ,[EffectiveFrom]
           ,[EffectiveTo]
           ,[CreatedByUserID]
           ,[CreatedAt])
     VALUES
           (@VisitType
           ,@BaseAmount
           ,@EffectiveFrom
           ,@EffectiveTo
           ,@CreatedByUserID
           ,@CreatedAt);

    set @VisitFeeID = SCOPE_IDENTITY();

end;