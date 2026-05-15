ALTER PROCEDURE InvoiceItem_Update
	@ItemID INT,
	@InvoiceID INT,
	@Description NVARCHAR(255),
	@Quantity INT,
	@UnitPrice DECIMAL(10, 2),
	@TotalPrice DECIMAL(10, 2)
AS
BEGIN

	UPDATE [dbo].[InvoiceItems]
    SET [InvoiceID] = @InvoiceID
      ,[Description] = @Description
      ,[Quantity] = @Quantity
      ,[UnitPrice] = @UnitPrice
      ,[TotalPrice] = @TotalPrice
	WHERE ItemID = @ItemID;

END;