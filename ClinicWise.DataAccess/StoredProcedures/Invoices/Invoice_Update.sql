ALTER PROCEDURE Invoice_Update
	@InvoiceID INT, 
    @SubTotal DECIMAL(10, 2), 
    @DiscountAmount DECIMAL(10, 2), 
    @DiscountPercent DECIMAL(5, 2), 
    @DiscountType TINYINT, 
    @DiscountAuthorizedByUserID INT, 
    @TotalAmount DECIMAL(10, 2),
    @AmountPaid DECIMAL(10, 2), 
    @OutstandingBalance DECIMAL(10, 2),
    @Status TINYINT, 
    @IssuedByUserID INT, 
    @IssuedAt DATETIME,
    @VoidedByUserID INT,
    @VoidedAt DATETIME,
    @VoidReason NVARCHAR(255),
    @Notes NVARCHAR(255)
AS
BEGIN

    UPDATE [dbo].[Invoices]
    SET [SubTotal] = @SubTotal
        ,[DiscountAmount] = @DiscountAmount 
        ,[DiscountPercent] = @DiscountPercent
        ,[DiscountType] = @DiscountType
        ,[DiscountAuthorizedByUserID] = @DiscountAuthorizedByUserID
        ,[TotalAmount] = @TotalAmount
        ,[AmountPaid] = @AmountPaid
        ,[OutstandingBalance] = @OutstandingBalance
        ,[Status] = @Status
        ,[IssuedByUserID] = @IssuedByUserID
        ,[IssuedAt] = @IssuedAt
        ,[VoidedByUserID] = @VoidedByUserID
        ,[VoidedAt] = @VoidedAt
        ,[VoidReason] = @VoidReason
        ,[Notes] = @Notes
    WHERE InvoiceID = @InvoiceID;

END;