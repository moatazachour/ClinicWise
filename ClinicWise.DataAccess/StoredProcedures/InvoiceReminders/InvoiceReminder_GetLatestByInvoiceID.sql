ALTER PROCEDURE InvoiceReminder_GetLatestByInvoiceID
	@InvoiceID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		InvoiceReminderID,
		InvoiceID,
		ReminderNumber,
		RecipientEmail,
		SentAt
	FROM InvoiceReminders
	WHERE InvoiceID = @InvoiceID
	ORDER BY SentAt DESC;
END;