Create View GetAllPersons_View 
As
With PersonData
As
(
	Select 
			PersonID,
			FullName = FirstName + ' ' + LastName,
			NationalNo,
			DateOfBirth,
			Gender = 
				Case
					When Gender = 0 Then 'Male'
					When Gender = 1 Then 'Female'
					Else 'Male'
				End,
			Phone,
			Email,
			Address,
			ImagePath,
			CreatedByUserID
		From Persons
)
Select * From PersonData;