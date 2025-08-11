create procedure Person_Update
	@NationalNo varchar(20),
	@FirstName varchar(100),
	@LastName varchar(100),
	@DateOfBirth datetime,
	@Gender tinyint,
	@Phone varchar(20),
	@Email varchar(100),
	@Address varchar(255),
	@PersonID int
as
begin
	set nocount on;	

	update Persons
	set FirstName = @FirstName,
		LastName = @LastName,
		DateOfBirth = @DateOfBirth,
		Gender = @Gender,
		Phone = @Phone,
		Email = @Email,
		Address = @Address,
		NationalNo = @NationalNo
	where PersonID = @PersonID;

	return @@ROWCOUNT;

end;