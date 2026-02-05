create procedure Medicament_GetByID
	@MedicamentID int
as
begin
	set nocount on;

	select
		MedicamentID,
		Name,
		Brand,
		DosageForm
	from Medicaments
	where MedicamentID = @MedicamentID;

end;