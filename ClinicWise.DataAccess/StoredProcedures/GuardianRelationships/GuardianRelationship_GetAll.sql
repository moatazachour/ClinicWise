CREATE PROCEDURE GuardianRelationship_GetAll
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT 
		GuardianRelationshipID,
		Name,
		Description
	FROM GuardianRelationships
END;