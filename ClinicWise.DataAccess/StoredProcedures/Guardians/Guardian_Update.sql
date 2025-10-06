CREATE PROCEDURE Guardian_Update
	@GuardianID INT,
	@RelationshipID INT
AS
BEGIN

	IF NOT EXISTS(SELECT found=1 FROM Guardians WHERE GuardianID = @GuardianID)
		RETURN;

	UPDATE Guardians
	SET RelationshipID = @RelationshipID
	WHERE GuardianID = @GuardianID;

END;