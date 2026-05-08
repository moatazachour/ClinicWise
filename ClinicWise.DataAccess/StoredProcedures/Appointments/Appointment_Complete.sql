CREATE PROCEDURE Appointment_Complete
	@AppointmentID INT
AS
BEGIN
	
	UPDATE Appointments
	SET Status = 3
	WHERE AppointmentID = @AppointmentID;

END;