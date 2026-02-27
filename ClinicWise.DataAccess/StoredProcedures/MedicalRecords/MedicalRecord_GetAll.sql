create procedure MedicalRecord_GetAll
as
begin
	set nocount on;

	select *
	from GetAllMedicalRecords_View;

end;