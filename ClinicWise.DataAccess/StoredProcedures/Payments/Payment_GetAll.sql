ALTER PROCEDURE Payment_GetAll
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		PaymentID,
		InvoiceID,
		InvoiceNumber,
		PaymentDate,
		Method,
		MethodLabel,
		AmountPaid,
		RecordedByUserID,
		RecordedBy
	FROM GetAllPayments_View;
END;