CREATE PROCEDURE MedicalRecord_DoesAppointmentHaveMedicalRecord
	@AppointmentID INT,
	@IsFound BIT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @IsFound = 0;

	SELECT @IsFound = 1
	FROM MedicalRecords
	WHERE AppointmentID = @AppointmentID;

END;