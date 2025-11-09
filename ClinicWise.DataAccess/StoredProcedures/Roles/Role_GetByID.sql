create procedure Role_GetByID
	@RoleID int
as
begin
	set nocount on;

	select *
	from Roles
	where RoleID = @RoleID;
end;