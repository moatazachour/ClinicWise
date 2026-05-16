CREATE PROCEDURE Invoice_GetLatestInvoiceByAppointmentID
	@AppointmentID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 *
	FROM Invoices
	WHERE AppointmentID = @AppointmentID
	ORDER BY InvoiceID DESC;

END;