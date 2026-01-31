create procedure MedicalRecord_GetByAppointmentID
	@AppointmentID int
as
begin
	set nocount on;

	select
		RecordID,
		DescriptionOfVisit,
		Diagnosis,
		AdditionalNotes,
		VisitType
	from
		MedicalRecords
	where
		AppointmentID = @AppointmentID;

end;