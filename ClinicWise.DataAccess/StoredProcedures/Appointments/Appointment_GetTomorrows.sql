alter procedure Appointment_GetTomorrows
as
begin
	set nocount on;

	select
		AppointmentID,
		DoctorFullLabel,
		PatientName,
		Date,
		StatusCaption,
		ScheduledBy
	from GetTomorrowsAppointments_View
	order by Date desc
end;