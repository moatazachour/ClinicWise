create procedure User_IsPersonAssignedToUserAccount
	@PersonID int,
	@Exists bit output
as
begin
	
	if exists(
			select found = 1 
			from Users 
			where PersonID = @PersonID)
		set @Exists = 1
	else
		set @Exists = 0

end;