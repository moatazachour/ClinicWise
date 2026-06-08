CREATE PROCEDURE Appointment_MarkReminderAsSent
	@AppointmentID INT
AS
BEGIN
	UPDATE Appointments
	SET ReminderSent = 1
	WHERE AppointmentID = @AppointmentID;
END;