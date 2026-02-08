create procedure PrescriptionItem_AddNew
	@RecordID int,
	@MedicamentID int,
	@Dosage varchar(100),
	@Frequency varchar(100),
	@Duration varchar(10),
	@SpecialInstruction varchar(255),
	@IsForever bit,
    @PrescriptionItemID int output
as
begin
	
    set nocount on;

	INSERT INTO [dbo].[PrescriptionItems]
           ([RecordID]
           ,[MedicamentID]
           ,[Dosage]
           ,[Frequency]
           ,[Duration]
           ,[SpecialInstruction]
           ,[IsForever])
     VALUES
           (@RecordID
           ,@MedicamentID
           ,@Dosage
           ,@Frequency
           ,@Duration
           ,@SpecialInstruction
           ,@IsForever)

    set @PrescriptionItemID = SCOPE_IDENTITY();

end;