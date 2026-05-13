ALTER PROCEDURE Invoice_GetAll
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		InvoiceID,
        InvoiceNumber,
        AppointmentID,
        PatientID,
        PatientName,
        TotalAmount,
        AmountPaid,
        OutstandingBalance,
        Status,
        StatusLabel,
        IssuedBy
	FROM GetAllInvoices_View;
END;