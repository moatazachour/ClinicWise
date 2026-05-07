ALTER procedure [dbo].[VisitFee_AddNew]
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
	
	begin try
		
		begin transaction;

		update VisitFees
		set EffectiveTo = @EffectiveFrom
		where VisitType = @VisitType
			and EffectiveTo is null;
		
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
		
		commit;

	end try

	begin catch
		rollback;
		throw;
	end catch;
end;