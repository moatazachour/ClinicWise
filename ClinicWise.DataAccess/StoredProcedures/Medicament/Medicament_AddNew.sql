alter procedure Medicament_AddNew
	@Name varchar(100),
	@Brand varchar(100),
	@DosageForm tinyint,
	@MedicamentID int output
as
begin
	set nocount on;

	insert into Medicaments (Name, Brand, DosageForm)
	values (@Name, @Brand, @DosageForm);

	set @MedicamentID = SCOPE_IDENTITY(); 
end;