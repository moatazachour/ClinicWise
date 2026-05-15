CREATE PROCEDURE InvoiceItem_Delete
	@ItemID INT
AS
BEGIN
	
	DELETE FROM InvoiceItems
	WHERE ItemID = @ItemID;

END;