Create Procedure Doctor_IsExistByNationalNo
	@NationalNo varchar(20),
	@Exists bit output
As
Begin
	
	Set Nocount On;

	If Exists(Select Found=1 
		      From Persons p Inner Join Doctors d
				  On p.PersonID = d.PersonID
			  Where NationalNo = @NationalNo)
		Set @Exists = 1;
	Else
		Set @Exists = 0;

End;