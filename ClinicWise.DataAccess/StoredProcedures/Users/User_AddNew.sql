CREATE PROCEDURE User_AddNew
	@PersonID int,
	@Username nvarchar(50),
	@Password nvarchar(100),
	@RoleID int,
	@IsActive bit,
	@CreatedByUserID int,
	@UserID int output
AS
BEGIN

	Insert Into Users (PersonID, Username, Password, RoleID, IsActive, CreatedByUserID)
	Values (@PersonID, @Username, @Password, @RoleID, @IsActive, @CreatedByUserID);

	set @UserID = SCOPE_IDENTITY();

END;