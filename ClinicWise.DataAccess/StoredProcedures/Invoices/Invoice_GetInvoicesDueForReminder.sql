ALTER PROCEDURE Invoice_GetInvoicesDueForReminder
    @InvoiceReminderIntervalDays TINYINT,
    @InvoiceReminderMaxCount     TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        I.InvoiceID,
        I.InvoiceNumber,
        I.PatientID,
        I.OutstandingBalance,
        I.TotalAmount,
        I.IssuedAt,
        COUNT(IR.InvoiceReminderID)  AS RemindersSentCount,
        MAX(IR.SentAt)               AS LastReminderSentAt

    FROM Invoices I
    LEFT JOIN InvoiceReminders IR ON IR.InvoiceID = I.InvoiceID

    WHERE I.OutstandingBalance > 0
      AND I.Status IN (1, 2)

    GROUP BY
        I.InvoiceID,
        I.InvoiceNumber,
        I.PatientID,
        I.OutstandingBalance,
        I.TotalAmount,
        I.IssuedAt

    HAVING
        COUNT(IR.InvoiceReminderID) < @InvoiceReminderMaxCount
        AND DATEDIFF(DAY, ISNULL(MAX(IR.SentAt), I.IssuedAt), GETDATE()) >= @InvoiceReminderIntervalDays;

END;