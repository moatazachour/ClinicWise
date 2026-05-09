CREATE PROCEDURE Invoice_GetByAppointmentAndStatus
	@AppointmentID INT,
	@Status TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Invoices
	WHERE AppointmentID = @AppointmentID
	AND Status = @Status
END;