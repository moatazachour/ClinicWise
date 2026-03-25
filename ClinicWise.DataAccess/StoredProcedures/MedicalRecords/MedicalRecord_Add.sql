alter procedure MedicalRecord_Add
	@AppointmentID int,
	@VisitType tinyint,
	@DescriptionOfVisit nvarchar(255),
	@Diagnosis nvarchar(255),
	@AdditionalNotes nvarchar(255),
	@ProcedureIncluded bit,
	@ProcedureName varchar(100),
	@RecordID int output
as
begin
	
	set nocount on;

	Insert Into MedicalRecords 
				(AppointmentID
				,VisitType
				,DescriptionOfVisit
				,Diagnosis
				,AdditionalNotes
				,ProcedureIncluded
				,ProcedureName)
		Values
				(@AppointmentID
				,@VisitType
				,@DescriptionOfVisit
				,@Diagnosis
				,@AdditionalNotes
				,@ProcedureIncluded
				,@ProcedureName)

	SET @RecordID = SCOPE_IDENTITY();

end;