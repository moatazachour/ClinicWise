CREATE procedure GuardianRelationship_GetByID
	@RelationshipID int
as
begin
	set nocount on;

	select *
	from GuardianRelationships
	where GuardianRelationshipID = 3;

end;