ALTER PROCEDURE [dbo].[Person_GetByNationalNo]
	@NationalNo VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Persons
	WHERE NationalNo = @NationalNo;
END;