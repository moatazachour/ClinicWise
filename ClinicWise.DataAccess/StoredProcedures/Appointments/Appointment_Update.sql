create procedure Appointment_Update
	@AppointmentID int,
	@DoctorID int,
	@PatientID int,
	@Date datetime,
	@Status tinyint,
	@ScheduledBy int
as
begin

	update Appointments
	set DoctorID = @DoctorID,
		PatientID = @PatientID,
		Date = @Date,
		Status = @Status,
		ScheduledBy = @ScheduledBy
	where AppointmentID = @AppointmentID;

end;