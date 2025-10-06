ALTER procedure GuardianRelationship_GetByName
	@RelationshipName nvarchar(100)
as
begin
	set nocount on;

	select *
	from GuardianRelationships
	where Name = @RelationshipName;

end;