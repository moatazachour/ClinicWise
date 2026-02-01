alter procedure Medicament_Update
	@MedicamentID int,
	@Name varchar(100),
	@Brand varchar(100),
	@DosageForm tinyint
as
begin
	if not exists(select found=1 from Medicament where MedicamentID = @MedicamentID)
		return;

	update Medicaments
	set Name = @Name,
		Brand = @Brand,
		DosageForm = @DosageForm
	where MedicamentID = @MedicamentID;

end;