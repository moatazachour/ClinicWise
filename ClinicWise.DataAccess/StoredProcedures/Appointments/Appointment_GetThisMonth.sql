create procedure Appointment_GetThisMonth
as
begin

	set nocount on;

	declare @Today date = GETDATE();
	declare @StartOfMonth date = DATEFROMPARTS(YEAR(@Today), MONTH(@Today), 1);
	declare @StartOfNextMonth date = DATEADD(DAY, 1, EOMONTH(@Today));

	select 
		AppointmentID,
		DoctorFullLabel,
		PatientName,
		[Date],
		StatusCaption,
		ScheduledBy
	from GetAllAppointments_View
	where [Date] >= @StartOfMonth
	  and [Date] < @StartOfNextMonth
	order by [DATE], AppointmentID;

end;