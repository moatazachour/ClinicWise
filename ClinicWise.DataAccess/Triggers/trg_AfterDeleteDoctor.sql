ALTER TRIGGER trg_AfterDeleteDoctor ON Doctors
AFTER DELETE
AS
BEGIN

	INSERT INTO DeleteDoctorLog(
		OriginalDoctorID,
		OriginalPersonID,
		SpecializationID,
		SpecializationName)
	SELECT
		DoctorID,
		PersonID,
		d.SpecializationID,
		s.Name
	From deleted d
		INNER JOIN Specializations s
		ON d.SpecializationID = s.SpecializationID;

END;