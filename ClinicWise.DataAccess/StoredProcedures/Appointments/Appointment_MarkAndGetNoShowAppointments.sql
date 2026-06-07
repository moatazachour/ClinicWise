CREATE PROCEDURE Appointment_MarkAndGetNoShowAppointments
    @NoShowThresholdMinutes INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MarkedIds TABLE (AppointmentID INT);

    UPDATE Appointments
    SET Status = 6
    OUTPUT inserted.AppointmentID INTO @MarkedIds
    WHERE Status IN (2, 5)
        AND DATEADD(MINUTE, @NoShowThresholdMinutes, Date) < GETDATE();

    SELECT v.*
    FROM GetAllAppointments_View v
    INNER JOIN @MarkedIds m
    ON v.AppointmentID = m.AppointmentID;
END;