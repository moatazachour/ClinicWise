CREATE PROCEDURE Doctor_AddNew
	@PersonID INT,
	@SpecializationID INT,
	@DoctorID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Doctors
				(PersonID
				,SpecializationID)
		Values
				(@PersonID
				,@SpecializationID);

	
	SET @DoctorID = SCOPE_IDENTITY();

END;