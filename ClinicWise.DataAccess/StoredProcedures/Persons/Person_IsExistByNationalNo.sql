Create Procedure Person_IsExistByNationalNo
	@NationalNo varchar(20),
	@Exists bit output
As
Begin
	
	Set Nocount On;

	If Exists(Select Found=1 
		      From Persons
			  Where NationalNo = @NationalNo)
		Set @Exists = 1;
	Else
		Set @Exists = 0;

End;