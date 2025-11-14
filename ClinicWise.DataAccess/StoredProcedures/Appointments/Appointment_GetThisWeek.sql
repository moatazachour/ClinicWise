alter procedure Appointment_GetThisWeek
as
begin
	set nocount on;

	SET DATEFIRST 1;  -- Use Monday as first day of week (SQL Server default is Sunday)
	declare @StartWeekDate date = DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), GETDATE());
	declare @NextMonday date = DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), GETDATE());

	select *
	from GetAllAppointments_View
	where Date >= @StartWeekDate
	  and Date < @NextMonday;
end;