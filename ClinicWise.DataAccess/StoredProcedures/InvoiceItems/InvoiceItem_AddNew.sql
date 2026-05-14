CREATE PROCEDURE InvoiceItem_AddNew
    @InvoiceID INT,
	@Description NVARCHAR(255),
    @Quantity INT,
    @UnitPrice DECIMAL(10, 2),
    @TotalPrice DECIMAL(10, 2),
    @ItemID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[InvoiceItems]
           ([InvoiceID]
           ,[Description]
           ,[Quantity]
           ,[UnitPrice]
           ,[TotalPrice])
     VALUES
           (@InvoiceID
           ,@Description
           ,@Quantity
           ,@UnitPrice
           ,@TotalPrice);

    SET @ItemID = SCOPE_IDENTITY();

END;