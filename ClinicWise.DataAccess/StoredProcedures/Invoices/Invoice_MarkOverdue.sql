ALTER PROCEDURE Invoice_MarkOverdue
	@InvoiceID INT
AS
BEGIN
	UPDATE Invoices
	SET Status = 6
	WHERE InvoiceID = @InvoiceID;
END;


