CREATE TRIGGER trg_AfterDeleteGuardian ON Guardians
AFTER DELETE
AS
BEGIN

	Delete FROM Persons
	WHERE PersonID = (SELECT d.PersonID FROM deleted d);

END;