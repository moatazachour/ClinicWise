create procedure Appointment_GetTodays
as
begin
	set nocount on;

	select *
	from GetTodaysAppointments_View
	order by Date desc
end;