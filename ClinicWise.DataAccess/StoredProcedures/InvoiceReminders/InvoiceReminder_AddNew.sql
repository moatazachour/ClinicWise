ALTER PROCEDURE InvoiceReminder_AddNew
	@InvoiceID INT,
	@ReminderNumber TINYINT,
	@RecipientEmail VARCHAR(100),
	@SentAt DATETIME,
	@InvoiceReminderID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[InvoiceReminders]
           ([InvoiceID]
           ,[ReminderNumber]
           ,[SentAt]
           ,[RecipientEmail])
     VALUES
           (@InvoiceID
           ,@ReminderNumber
           ,@SentAt
           ,@RecipientEmail);

    SET @InvoiceReminderID = SCOPE_IDENTITY();

END;