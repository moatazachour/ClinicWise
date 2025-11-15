create procedure Appointment_GetNextMonth
as
begin

	set nocount on;

	declare @Today date = GETDATE();
	declare @StartOfNextMonth date = DATEADD(DAY, 1, EOMONTH(@Today));
	declare @StartOfMonthAfterNextMonth date = DATEADD(DAY, 1, EOMONTH(@StartOfNextMonth));

	select 
		AppointmentID,
		DoctorFullLabel,
		PatientName,
		[Date],
		StatusCaption,
		ScheduledBy
	from GetAllAppointments_View
	where [Date] >= @StartOfNextMonth
	  and [Date] < @StartOfMonthAfterNextMonth
	order by [DATE], AppointmentID;

end;