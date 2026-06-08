ALTER PROCEDURE Appointment_GetTomorrowsPendingReminder
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		AppointmentID,
		DoctorFullLabel,
		PatientName,
		PatientEmail,
		Date,
		StatusCaption,
		ScheduledBy,
		ReminderSent
	FROM GetTomorrowsAppointments_View
	WHERE ReminderSent = 0;

END;