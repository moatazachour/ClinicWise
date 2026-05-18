ALTER PROCEDURE Payment_Update
    @PaymentID INT,
    @PaymentDate DATETIME,
    @Method TINYINT,
    @AmountPaid DECIMAL(10, 2),
    @RecordedByUserID INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION;

        DECLARE @PaymentAmountBeforeUpdate DECIMAL(10, 2);
        DECLARE @ResolvedInvoiceID INT;

        SELECT @PaymentAmountBeforeUpdate = AmountPaid,
               @ResolvedInvoiceID = InvoiceID
        FROM Payments
        WHERE PaymentID = @PaymentID;

        IF @PaymentAmountBeforeUpdate IS NULL
            THROW 50002, 'Payment record not found.', 1;

        IF @AmountPaid > (SELECT OutstandingBalance + @PaymentAmountBeforeUpdate FROM Invoices WHERE InvoiceID = @ResolvedInvoiceID)
            THROW 50001, 'Payment exceeds outstanding balance.', 1;

        UPDATE Invoices
        SET AmountPaid = AmountPaid - @PaymentAmountBeforeUpdate + @AmountPaid,
            OutstandingBalance = OutstandingBalance + @PaymentAmountBeforeUpdate - @AmountPaid,
            Status =
                CASE
                    WHEN (OutstandingBalance + @PaymentAmountBeforeUpdate - @AmountPaid) > 0 THEN 2
                    WHEN (OutstandingBalance + @PaymentAmountBeforeUpdate - @AmountPaid) = 0 THEN 3
                    ELSE 2
                END
        WHERE InvoiceID = @ResolvedInvoiceID;

        UPDATE [dbo].[Payments]
        SET [PaymentDate] = @PaymentDate,
            [Method] = @Method,
            [AmountPaid] = @AmountPaid,
            [RecordedByUserID] = @RecordedByUserID
        WHERE PaymentID = @PaymentID;

        COMMIT;

    END TRY

    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH;

END;