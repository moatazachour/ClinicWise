CREATE PROCEDURE Specialization_GetByID
	@SpecializationID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Specializations
	WHERE SpecializationID = @SpecializationID;

END;