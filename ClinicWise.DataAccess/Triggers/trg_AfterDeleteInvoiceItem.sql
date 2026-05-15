CREATE TRIGGER trg_AfterDeleteInvoiceItem ON InvoiceItems
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE inv
    SET
        SubTotal    = inv.SubTotal - del.SubstractedAmount,
        TotalAmount = CASE
                          WHEN inv.DiscountAmount > 0
                              THEN (inv.SubTotal - del.SubstractedAmount) - inv.DiscountAmount
                          WHEN inv.DiscountPercent IS NOT NULL
                              THEN (inv.SubTotal - del.SubstractedAmount) * (1 - inv.DiscountPercent / 100)
                          ELSE (inv.SubTotal - del.SubstractedAmount)
                      END,
        OutstandingBalance = CASE
                                 WHEN inv.DiscountAmount > 0
                                     THEN (inv.SubTotal - del.SubstractedAmount) - inv.DiscountAmount
                                 WHEN inv.DiscountPercent IS NOT NULL
                                     THEN (inv.SubTotal - del.SubstractedAmount) * (1 - inv.DiscountPercent / 100)
                                 ELSE (inv.SubTotal - del.SubstractedAmount)
                             END
    FROM Invoices inv
    INNER JOIN (
        SELECT InvoiceID, SUM(TotalPrice) AS SubstractedAmount
        FROM deleted
        GROUP BY InvoiceID
    ) del ON inv.InvoiceID = del.InvoiceID;
END;