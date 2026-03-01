create procedure PrescriptionItem_GetByID
	@PrescriptionItemID int
as
begin
	set nocount on;
		
	select
		RecordID,
		MedicamentID,
		Dosage,
		Frequency,
		Duration,
		SpecialInstruction,
		IsForever
	from
		PrescriptionItems
	where
		ItemID = @PrescriptionItemID;

end;