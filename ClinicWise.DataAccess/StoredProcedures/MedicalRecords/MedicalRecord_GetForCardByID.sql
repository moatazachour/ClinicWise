create procedure MedicalRecord_GetForCardByID
	@MedicalRecordID int
as
begin
	set nocount on;

	select *
	from GetAllMedicalRecords_View
	where RecordID = @MedicalRecordID;

end;