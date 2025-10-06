CREATE PROCEDURE Guardian_AddNew
	@PersonID INT,
	@RelationshipID INT,
	@GuardianID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Guardians
				(PersonID
				,RelationshipID)
		Values
				(@PersonID
				,@RelationshipID);

	SET @GuardianID = SCOPE_IDENTITY();

END;