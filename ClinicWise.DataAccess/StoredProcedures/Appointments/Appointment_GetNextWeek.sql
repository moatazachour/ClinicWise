alter procedure Appointment_GetNextWeek
as
begin
	set nocount on;

	SET DATEFIRST 1;
	declare @StartOfNextWeek date = DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), GETDATE())
	declare @StartOfTheWeekAfter date = DATEADD(WEEK, 1, @StartOfNextWeek)

	select *
	from GetAllAppointments_View
	where Date >= @StartOfNextWeek
	  and Date < @StartOfTheWeekAfter
	order by Date;
end;