create procedure PrescriptionItem_GetAllByMedicalRecord
	@MedicalRecordID int
as
begin
	set nocount on;

	select *
	from PrescriptionItem_GetAll
	where RecordID = @MedicalRecordID;
end;