create procedure PrescriptionItem_Delete
	@ItemID int
as
begin
	
	delete from PrescriptionItems
	where ItemID = @ItemID;

end;