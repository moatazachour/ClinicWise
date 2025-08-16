CREATE TRIGGER trg_AfterDeletePerson ON Persons
AFTER DELETE
AS
BEGIN

	INSERT INTO DeletePersonLog(
		OriginalPersonID,
		NationalNo,
		FirstName,
		LastName,
		DateOfBirth,
		Gender,
		Phone,
		Email,
		Address,
		DeletedBy)
	SELECT
		d.PersonID,
		d.NationalNo,
		d.FirstName,
		d.LastName,
		d.DateOfBirth,
		d.Gender,
		d.Phone,
		d.Email,
		d.Address,
		d.DeletedByUserID
	From deleted d;

END;