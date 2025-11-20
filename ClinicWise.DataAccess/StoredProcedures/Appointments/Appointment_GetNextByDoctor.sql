CREATE procedure Appointment_GetNextByDoctor
	@DoctorID int
as
begin
	set nocount on;

	select *
	from GetAllAppointments_View
	where DoctorID = @DoctorID
		and Date > GETDATE()
	order by Date ASC
end;