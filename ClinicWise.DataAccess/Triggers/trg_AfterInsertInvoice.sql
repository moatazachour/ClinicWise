CREATE TRIGGER trg_AfterInsertInvoice ON Invoices
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[InvoiceItems]
           ([InvoiceID]
           ,[Description]
           ,[Quantity]
           ,[UnitPrice]
           ,[TotalPrice]
           ,[VisitFeeID])
    SELECT
        i.InvoiceID,
        CASE mr.VisitType
            WHEN 1 THEN 'Consultation'
            WHEN 2 THEN 'Follow Up'
            WHEN 3 THEN 'Emergency'
            WHEN 4 THEN 'Routine Check'
            WHEN 5 THEN 'Vaccination'
            ELSE 'Lab Test'
        END + ' - ' + mr.DescriptionOfVisit,
        1,
        vf.BaseAmount,
        vf.BaseAmount,
        vf.VisitFeeID

    FROM inserted i
    INNER JOIN Appointments a ON i.AppointmentID = a.AppointmentID
    INNER JOIN MedicalRecords mr ON a.AppointmentID = mr.AppointmentID
    INNER JOIN VisitFees vf ON mr.VisitType = vf.VisitType
        AND dbo.CheckIfFeeIsActive(vf.EffectiveFrom, vf.EffectiveTo) = 1
END;