ALTER Procedure Person_AddNew
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
				,Address
				,ImagePath
				,CreatedByUserID)
		Values
				(@NationalNo
				,@FirstName
				,@LastName
				,@DateOfBirth
				,@Gender
				,@Phone
				,@Email
				,@Address
				,@ImagePath
				,@CreatedByUserID);

	Set @PersonID = SCOPE_IDENTITY();
END;