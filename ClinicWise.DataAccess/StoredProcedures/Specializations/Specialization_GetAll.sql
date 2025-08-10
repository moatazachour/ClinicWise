CREATE PROCEDURE Specialization_GetAll
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Specializations;

END;