create procedure Appointment_GetTomorrows
as
begin
	set nocount on;

	select *
	from GetTomorrowsAppointments_View
	order by Date desc
end;