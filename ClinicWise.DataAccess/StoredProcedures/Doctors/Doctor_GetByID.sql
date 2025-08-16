ALTER PROCEDURE Doctor_GetByID
	@DoctorID INT
AS

BEGIN
	SET NOCOUNT ON;

	SELECT 
		d.PersonID,
		d.SpecializationID,
		p.FirstName,
		p.LastName,
		p.DateOfBirth,
		p.Gender,
		p.Phone,
		p.Email,
		p.Address,
		p.NationalNo,
		p.ImagePath,
		p.CreatedByUserID
	FROM Doctors d
	INNER JOIN Persons p
		ON d.PersonID = p.PersonID
	WHERE d.DoctorID = @DoctorID

END;