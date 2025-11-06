Create View GetAllUsers_View
As
With UserData
As
(
	Select 
		u.UserID,
		u.Username,
		r.RoleName,
		IsActiveCaption = 
			Case
				When u.IsActive = 0 Then 'Inactive'
				When u.Isactive = 1 Then 'Active'
				Else 'Inactive'
			End,
		CreatedBy = (Select Username From Users Where UserID = u.CreatedByUserID)
	From Users u
		Inner Join Roles r 
		On u.RoleID = r.RoleID
)
Select * From UserData;