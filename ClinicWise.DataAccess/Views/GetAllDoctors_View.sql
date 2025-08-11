Create View GetAllDoctors_View 
As
With DoctorData
As
(
	Select 
			d.DoctorID,
			FullName = p.FirstName + ' ' + p.LastName,
			p.NationalNo,
			s.Name As Specialization,
			p.DateOfBirth,
			Gender = 
				Case
					When p.Gender = 0 Then 'Male'
					When p.Gender = 1 Then 'Female'
					Else 'Male'
				End,
			p.Phone,
			p.Email,
			p.Address
		From Doctors d
		Inner Join Persons p
			On d.PersonID = p.PersonID
		Inner Join Specializations s
			On d.SpecializationID = s.SpecializationID
)
Select * From DoctorData;