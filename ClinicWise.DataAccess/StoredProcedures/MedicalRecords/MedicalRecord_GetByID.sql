alter procedure MedicalRecord_GetByID
	@RecordID int
as
begin
	set nocount on;

	select
		AppointmentID,
		DescriptionOfVisit,
		Diagnosis,
		AdditionalNotes,
		VisitType,
		ProcedureIncluded,
		ProcedureName
	from
		MedicalRecords
	where
		RecordID = @RecordID;

end;