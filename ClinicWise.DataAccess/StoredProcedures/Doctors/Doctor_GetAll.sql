Create Procedure Doctor_GetAll
As
Begin
	Set Nocount On;

	Select *
	From GetAllDoctors_View
	Order By FullName

End;