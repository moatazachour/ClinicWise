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
		CreatedBy = c.Username
	From Users u
		Inner Join Roles r 
		On u.RoleID = r.RoleID
		Left Join Users c
		On u.CreatedByUserID = c.UserID
)
Select * From UserData;