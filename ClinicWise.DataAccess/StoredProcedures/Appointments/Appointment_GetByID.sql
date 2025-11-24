create procedure Appointment_GetByID
	@AppointmentID int
as
begin
	set nocount on;

	select *
	from Appointments
	where AppointmentID = @AppointmentID;

end;