CREATE PROCEDURE Patient_Delete
	@PatientID INT,
	@DeletedByUserID INT,
	@RowsAffected INT OUTPUT
AS
BEGIN

	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @PersonID INT;
		SELECT @PersonID = PersonID FROM Patients WHERE PatientID = @PatientID;

		IF NOT EXISTS(SELECT 1 FROM Patients WHERE PatientID = @PatientID AND PersonID = @PersonID)
			RETURN;

		UPDATE Persons
		SET DeletedByUserID = @DeletedByUserID
		WHERE PersonID = @PersonID;

		DECLARE @DeletedPatients INT = 0, @DeletedPersons INT = 0;

		DELETE FROM Patients WHERE PatientID = @PatientID;
		SET @DeletedPatients = @@ROWCOUNT;

		DELETE FROM Persons WHERE PersonID = @PersonID;
		SET @DeletedPersons = @@ROWCOUNT;

		SET @RowsAffected = @DeletedPatients + @DeletedPersons;

		COMMIT;
	END TRY

	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH;

END;