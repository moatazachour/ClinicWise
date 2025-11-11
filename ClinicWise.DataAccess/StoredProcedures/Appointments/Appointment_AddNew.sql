create procedure Appointment_AddNew
	@DoctorID int,
	@PatientID int,
	@Date datetime,
	@Status tinyint,
	@ScheduledBy int,
	@AppointmentID int output
as
begin

	set nocount on;

	insert into Appointments(DoctorID, PatientID, Date, Status, ScheduledBy)
	values (@DoctorID, @PatientID, @Date, @Status, @ScheduledBy)

	set @AppointmentID = SCOPE_IDENTITY();

end;