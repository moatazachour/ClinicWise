Create Procedure Person_AddNew
	@NationalNo varchar(20),
	@FirstName varchar(100),
	@LastName varchar(100),
	@DateOfBirth datetime,
	@Gender tinyint,
	@Phone varchar(20),
	@Email varchar(100),
	@Address varchar(255),
	@PersonID int output
As
Begin
	SET NOCOUNT ON;

	Insert Into Persons 
				(NationalNo
				,FirstName
				,LastName
				,DateOfBirth
				,Gender
				,Phone
				,Email
				,Address)
		Values
				(@NationalNo
				,@FirstName
				,@LastName
				,@DateOfBirth
				,@Gender
				,@Phone
				,@Email
				,@Address);

	Set @PersonID = SCOPE_IDENTITY();
END;