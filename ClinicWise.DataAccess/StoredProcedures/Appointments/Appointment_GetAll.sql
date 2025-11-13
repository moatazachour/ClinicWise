create procedure Appointment_GetAll
as
begin
	set nocount on;

	select *
	from GetAllAppointments_View
	order by Date desc
end;