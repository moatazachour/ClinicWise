create procedure MedicalRecord_Add
	@AppointmentID int,
	@VisitType tinyint,
	@DescriptionOfVisit nvarchar(255),
	@Diagnosis nvarchar(255),
	@AdditionalNotes nvarchar(255),
	@RecordID int output
as
begin
	
	set nocount on;

	Insert Into MedicalRecords 
				(AppointmentID
				,VisitType
				,DescriptionOfVisit
				,Diagnosis
				,AdditionalNotes)
		Values
				(@AppointmentID
				,@VisitType
				,@DescriptionOfVisit
				,@Diagnosis
				,@AdditionalNotes)

	SET @RecordID = SCOPE_IDENTITY();

end;