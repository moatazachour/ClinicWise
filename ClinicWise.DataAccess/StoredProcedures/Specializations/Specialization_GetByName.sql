CREATE PROCEDURE Specialization_GetByName
	@Name VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Specializations
	WHERE Name = @Name;

END;