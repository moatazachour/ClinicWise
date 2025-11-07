create procedure User_GetAll
as
begin
	set nocount on;

	select *
	from GetAllUsers_View
end;