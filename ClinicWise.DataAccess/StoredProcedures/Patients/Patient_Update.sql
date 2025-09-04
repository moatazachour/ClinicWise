CREATE PROCEDURE Patient_Update
	@PatientID INT,
	@GuardianID INT
AS
BEGIN

	IF NOT EXISTS(SELECT found=1 FROM Patients WHERE PatientID = @PatientID)
		RETURN;

	UPDATE Patients
	SET GuardianID = @GuardianID
	WHERE PatientID = @PatientID;

END;