alter view GetTomorrowsAppointments_View
as
with TomorrowAppointments
as
(
	select
		AppointmentID,
		DoctorFullLabel,
		PatientName,
		PatientEmail,
		Date,
		StatusCaption,
		ScheduledBy,
		ReminderSent
	from GetAllAppointments_View
	where Date >= DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
	  and Date < DATEADD(DAY, 2, CAST(GETDATE() AS DATE))
)
select * from TomorrowAppointments;