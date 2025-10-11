ALTER TRIGGER trg_AfterDeletePatient ON Patients
AFTER DELETE
AS
BEGIN

	INSERT INTO DeletePatientLog(
		OriginalPatientID,
		OriginalPersonID)
	SELECT
		PatientID,
		PersonID
	From deleted d

	Delete FROM Guardians
	WHERE GuardianID = (SELECT d.GuardianID FROM deleted d)

END;