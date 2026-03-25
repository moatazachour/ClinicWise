alter procedure MedicalRecord_Update
	@RecordID int,
	@VisitType tinyint,
	@DescriptionOfVisit nvarchar(255),
	@Diagnosis nvarchar(255),
	@AdditionalNotes nvarchar(255),
	@ProcedureIncluded bit,
	@ProcedureName varchar(100)
as
begin
	
	Update MedicalRecords 
	Set VisitType = @VisitType
		,DescriptionOfVisit = @DescriptionOfVisit
		,Diagnosis = @Diagnosis 
		,AdditionalNotes = @AdditionalNotes
		,ProcedureIncluded = @ProcedureIncluded
		,ProcedureName = @ProcedureName
	Where RecordID = @RecordID;
	
end;