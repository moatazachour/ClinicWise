ALTER PROCEDURE Person_GetByNationalNo
	@NationalNo VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM GetAllPersons_View
	WHERE NationalNo = @NationalNo;
END;