CREATE PROCEDURE Guardian_GetByID
	@GuardianID INT
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT 
		g.PersonID,
		p.NationalNo,
		p.FirstName,
		p.LastName,
		p.DateOfBirth,
		p.Gender,
		p.Phone,
		p.Email,
		p.Address,
		p.ImagePath,
		p.CreatedByUserID,
		g.RelationshipID
	FROM Guardians g
	INNER JOIN Persons p
	ON g.PersonID = p.PersonID
	WHERE GuardianID = @GuardianID;
END;