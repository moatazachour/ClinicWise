ALTER TRIGGER trg_AfterUpdateInvoiceItem ON InvoiceItems
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE inv
    SET
        SubTotal    = inv.SubTotal + ins.AddedAmount - del.AddedAmount,
        TotalAmount = CASE
                          WHEN inv.DiscountAmount > 0
                              THEN (inv.SubTotal + ins.AddedAmount - del.AddedAmount) - inv.DiscountAmount
                          WHEN inv.DiscountPercent IS NOT NULL
                              THEN (inv.SubTotal + ins.AddedAmount - del.AddedAmount) * (1 - inv.DiscountPercent / 100)
                          ELSE (inv.SubTotal + ins.AddedAmount - del.AddedAmount)
                      END,
        OutstandingBalance = CASE
                                  WHEN inv.DiscountAmount > 0
                                      THEN (inv.SubTotal + ins.AddedAmount - del.AddedAmount) - inv.DiscountAmount
                                  WHEN inv.DiscountPercent IS NOT NULL
                                      THEN (inv.SubTotal + ins.AddedAmount - del.AddedAmount) * (1 - inv.DiscountPercent / 100)
                                  ELSE (inv.SubTotal + ins.AddedAmount - del.AddedAmount)
                            END
    FROM Invoices inv
    INNER JOIN (
        SELECT InvoiceID, SUM(TotalPrice) AS AddedAmount
        FROM inserted
        GROUP BY InvoiceID
    ) ins ON inv.InvoiceID = ins.InvoiceID
    INNER JOIN (
        SELECT InvoiceID, SUM(TotalPrice) AS AddedAmount
        FROM deleted
        GROUP BY InvoiceID
    ) del ON inv.InvoiceID = del.InvoiceID;
END;