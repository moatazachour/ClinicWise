create procedure User_GetByID
	@UserID int
as
begin
	set nocount on;

	select 
		u.UserID,
		u.Username,
		u.IsActive,
		r.RoleName
	from Users u
		inner join Roles r
		on u.RoleID = r.RoleID
end;