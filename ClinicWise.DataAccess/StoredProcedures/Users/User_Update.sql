create procedure User_Update
	@UserID int,
	@Username nvarchar(50),
	@Password nvarchar(100),
	@RoleID int,
	@IsActive bit
as
begin
	set nocount on;

	update Users
	set Username = @Username,
		Password = @Password,
		RoleID = @RoleID,
		IsActive = @IsActive
	where UserID = @UserID

	return @@ROWCOUNT;
end;