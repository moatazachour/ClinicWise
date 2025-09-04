CREATE PROCEDURE Patient_AddNew
	@PersonID INT,
	@GuardianID INT,
	@PatientID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Patients
				(PersonID
				,GuardianID)
		Values
				(@PersonID
				,@GuardianID);

	SET @PatientID = SCOPE_IDENTITY();

END;