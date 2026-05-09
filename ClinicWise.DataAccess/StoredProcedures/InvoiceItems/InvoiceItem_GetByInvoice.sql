CREATE PROCEDURE InvoiceItem_GetByInvoice
	@InvoiceID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM InvoiceItems
	WHERE InvoiceID = @InvoiceID;
END;