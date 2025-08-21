ALTER procedure Person_Update
	@NationalNo varchar(20),
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@DateOfBirth datetime,
	@Gender tinyint,
	@Phone nvarchar(20),
	@Email nvarchar(100),
	@Address nvarchar(255),
	@ImagePath nvarchar(250),
	@CreatedByUserID int,
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
		NationalNo = @NationalNo,
		ImagePath = @ImagePath,
		CreatedByUserID = @CreatedByUserID
	where PersonID = @PersonID;

	return @@ROWCOUNT;

end;