CREATE PROCEDURE [dbo].[DeleteUserByID]
@ID int
AS
BEGIN
UPDATE [dbo].[User]
SET IsDeleted = 1
WHERE (@ID = ID AND IsDeleted = 0)
END