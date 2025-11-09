create procedure User_GetByUsernameAndPassword
	@Username nvarchar(50),
	@Password nvarchar(100)
as
begin
	set nocount on;

	select *
	from Users
	where Username = @Username and Password = @Password;
end;