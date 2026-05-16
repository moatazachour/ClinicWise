ALTER TRIGGER trg_AfterVoidingInvoice ON Invoices
AFTER UPDATE
AS
BEGIN

    SET NOCOUNT ON;

    IF UPDATE(Status) AND EXISTS (SELECT 1 FROM inserted WHERE Status = 5)
    BEGIN
        INSERT INTO [dbo].[Invoices]
           ([InvoiceNumber]
           ,[AppointmentID]
           ,[PatientID]
           ,[SubTotal]
           ,[TotalAmount]
           ,[Status])
        
        SELECT
            'INV-' + RIGHT('00000' + CAST(
                (SELECT COUNT(*) + 1 FROM Invoices)
            AS VARCHAR(5)), 5),
            i.AppointmentID,
            i.PatientID,
            0,
            0,
            0

        FROM inserted i
        INNER JOIN deleted d ON i.AppointmentID = d.AppointmentID
        INNER JOIN MedicalRecords mr ON i.AppointmentID = mr.AppointmentID
        INNER JOIN VisitFees vf ON mr.VisitType = vf.VisitType
            AND dbo.CheckIfFeeIsActive(vf.EffectiveFrom, vf.EffectiveTo) = 1

        WHERE i.Status = 5 AND d.Status <> 5;
    END
END;