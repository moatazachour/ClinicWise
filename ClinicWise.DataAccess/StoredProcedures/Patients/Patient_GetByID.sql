CREATE PROCEDURE Patient_GetByID
	@PatientID INT
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT 
		pat.PersonID,
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
		pat.GuardianID
	FROM Patients pat
	INNER JOIN Persons p
	ON pat.PersonID = p.PersonID
	WHERE PatientID = @PatientID
END;