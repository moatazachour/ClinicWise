alter view GetTodaysAppointments_View
as
with TodayAppointments
as
(
	select AppointmentID, DoctorFullLabel, PatientName, Date, StatusCaption, ScheduledBy
	from GetAllAppointments_View
	where Date >= CAST(GETDATE() AS DATE)
		and Date < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
)
select * from TodayAppointments;