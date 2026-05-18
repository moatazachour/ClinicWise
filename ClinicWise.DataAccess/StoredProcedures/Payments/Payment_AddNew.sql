ALTER PROCEDURE Payment_AddNew
    @InvoiceID INT,
    @PaymentDate DATETIME,
    @Method TINYINT,
    @AmountPaid DECIMAL(10, 2),
    @RecordedByUserID INT,
    @PaymentID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        DECLARE @OutstandingBalance DECIMAL(10, 2);
        DECLARE @InvoiceStatus TINYINT;

        SELECT @OutstandingBalance = OutstandingBalance,
               @InvoiceStatus = Status
        FROM Invoices
        WHERE InvoiceID = @InvoiceID;

        IF @OutstandingBalance IS NULL
            THROW 50003, 'Invoice not found.', 1;

        IF @InvoiceStatus IN (3, 4)
            THROW 50004, 'Cannot add payment to a fully paid or waived invoice.', 1;

        IF @AmountPaid > @OutstandingBalance
            THROW 50001, 'Payment exceeds outstanding balance.', 1;

        UPDATE Invoices
        SET AmountPaid = AmountPaid + @AmountPaid,
            OutstandingBalance = OutstandingBalance - @AmountPaid,
            Status =
                CASE
                    WHEN (OutstandingBalance - @AmountPaid) > 0 THEN 2
                    WHEN (OutstandingBalance - @AmountPaid) = 0 THEN 3
                    ELSE 2
                END
        WHERE InvoiceID = @InvoiceID;

        INSERT INTO [dbo].[Payments]
               ([InvoiceID]
               ,[PaymentDate]
               ,[Method]
               ,[AmountPaid]
               ,[RecordedByUserID])
        VALUES
               (@InvoiceID
               ,@PaymentDate
               ,@Method
               ,@AmountPaid
               ,@RecordedByUserID);

        SET @PaymentID = SCOPE_IDENTITY();

        COMMIT;

    END TRY

    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH;

END;