create procedure Appointment_GetByPatient
	@PatientID int
as
begin
	set nocount on;

	select *
	from GetAllAppointments_View
	where PatientID = @PatientID
		and Date > GETDATE()
	order by Date asc;
end;