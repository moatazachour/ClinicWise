ALTER Procedure Doctor_ExistsForPerson
	@PersonID int,
	@Exists bit output
As
Begin
	
	Set Nocount On;

	If Exists(Select Found=1 
		      From Doctors
			  Where PersonID = @PersonID)
		Set @Exists = 1;
	Else
		Set @Exists = 0;

End;