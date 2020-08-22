CREATE PROCEDURE [dbo].[RestoreDeletedUserByID]
@ID int
AS
BEGIN
UPDATE [dbo].[User]
SET IsDeleted = 0
WHERE (@ID = ID AND IsDeleted = 1)
END