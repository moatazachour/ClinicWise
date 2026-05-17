CREATE PROCEDURE Invoice_GetByInvoiceNumber
	@InvoiceNumber VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Invoices
	WHERE InvoiceNumber = @InvoiceNumber;
END;