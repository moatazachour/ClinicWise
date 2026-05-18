ALTER VIEW GetAllPayments_View
AS
SELECT
	p.PaymentID,
	p.InvoiceID,
	i.InvoiceNumber,
	p.PaymentDate,
	p.Method,
	CASE p.Method
		WHEN 1 THEN 'Cash'
		WHEN 2 THEN 'Card'
		WHEN 3 THEN 'Bank Transfer'
		WHEN 4 THEN 'Insurance'
		ELSE 'Cash'
	END AS MethodLabel,
	p.AmountPaid,
	p.RecordedByUserID,
	u.Username AS RecordedBy
FROM Payments p
INNER JOIN Invoices i ON p.InvoiceID = i.InvoiceID
INNER JOIN Users u ON p.RecordedByUserID = u.UserID;