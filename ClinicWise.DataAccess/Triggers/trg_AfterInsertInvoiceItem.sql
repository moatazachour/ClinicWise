ALTER TRIGGER trg_AfterInsertInvoiceItem ON InvoiceItems
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE inv
    SET
        SubTotal    = inv.SubTotal + agg.AddedAmount,
        TotalAmount = CASE
                          WHEN inv.DiscountAmount > 0
                              THEN (inv.SubTotal + agg.AddedAmount) - inv.DiscountAmount
                          WHEN inv.DiscountPercent IS NOT NULL
                              THEN (inv.SubTotal + agg.AddedAmount) * (1 - inv.DiscountPercent / 100)
                          ELSE (inv.SubTotal + agg.AddedAmount)
                      END,
        OutstandingBalance = CASE
                             WHEN inv.DiscountAmount > 0
                                 THEN (inv.SubTotal + agg.AddedAmount) - inv.DiscountAmount
                             WHEN inv.DiscountPercent IS NOT NULL
                                 THEN (inv.SubTotal + agg.AddedAmount) * (1 - inv.DiscountPercent / 100)
                             ELSE (inv.SubTotal + agg.AddedAmount)
                         END - inv.AmountPaid
    FROM Invoices inv
    INNER JOIN (
        SELECT InvoiceID, SUM(TotalPrice) AS AddedAmount
        FROM inserted
        GROUP BY InvoiceID
    ) agg ON inv.InvoiceID = agg.InvoiceID;
END;