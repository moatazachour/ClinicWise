create procedure Doctor_Update
	@DoctorID INT,
	@SpecializationID INT
as
begin
	
	if not exists(select found=1 from Doctors where DoctorID = @DoctorID)
		return;

	update Doctors
	set SpecializationID = @SpecializationID
	where DoctorID = @DoctorID

end;