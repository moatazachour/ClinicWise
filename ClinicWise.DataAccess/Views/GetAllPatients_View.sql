Create View GetAllPatients_View 
As
With PatientData
As
(
	Select 
			pat.PatientID,
			FullName = p.FirstName + ' ' + p.LastName,
			p.NationalNo,
			p.DateOfBirth,
			Gender = 
				Case
					When p.Gender = 0 Then 'Male'
					When p.Gender = 1 Then 'Female'
					Else 'Male'
				End,
			p.Phone,
			p.Email,
			p.Address,
			pat.GuardianID
		From Patients pat
		Inner Join Persons p
			On pat.PersonID = p.PersonID
)
Select * From PatientData;