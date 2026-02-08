create procedure PrescriptionItem_Update
    @PrescriptionItemID int,
	@RecordID int,
	@MedicamentID int,
	@Dosage varchar(100),
	@Frequency varchar(100),
	@Duration varchar(10),
	@SpecialInstruction varchar(255),
	@IsForever bit
as
begin
	
    UPDATE [dbo].[PrescriptionItems]
	SET [RecordID] = @RecordID
		,[MedicamentID] = @MedicamentID
		,[Dosage] = @Dosage
		,[Frequency] = @Frequency
		,[Duration] = @Duration
		,[SpecialInstruction] = @SpecialInstruction
		,[IsForever] = @IsForever
	WHERE ItemID = @PrescriptionItemID;

end;