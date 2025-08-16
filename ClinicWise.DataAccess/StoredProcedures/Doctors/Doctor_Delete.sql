ALTER PROCEDURE [dbo].[Doctor_Delete]
	@DoctorID INT,
	@DeletedByUserID INT,
	@RowsAffected INT OUTPUT
AS
BEGIN

	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @PersonID INT;
		SELECT @PersonID = PersonID FROM Doctors WHERE DoctorID = @DoctorID;

		IF NOT EXISTS(SELECT 1 FROM Doctors WHERE DoctorID = @DoctorID AND PersonID = @PersonID)
			RETURN;

		UPDATE Persons
		SET DeletedByUserID = @DeletedByUserID
		WHERE PersonID = @PersonID;

		DECLARE @DeletedDoctors INT = 0, @DeletedPersons INT = 0;

		DELETE FROM Doctors WHERE DoctorID = @DoctorID;
		SET @DeletedDoctors = @@ROWCOUNT;

		DELETE FROM Persons WHERE PersonID = @PersonID;
		SET @DeletedPersons = @@ROWCOUNT;

		SET @RowsAffected = @DeletedDoctors + @DeletedPersons;

		COMMIT;
	END TRY

	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH;

END;