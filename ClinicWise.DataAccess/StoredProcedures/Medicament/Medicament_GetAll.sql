create procedure Medicament_GetAll
as
begin
	set nocount on;

	select
		MedicamentID,
		Name,
		Brand,
		DosageForm
	from Medicaments;

end;