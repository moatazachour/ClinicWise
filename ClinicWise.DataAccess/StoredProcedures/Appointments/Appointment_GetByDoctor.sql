CREATE procedure Appointment_GetByDoctor
	@DoctorID int
as
begin
	set nocount on;

	select *
	from GetAllAppointments_View
	where DoctorID = @DoctorID
	order by Date desc
end;