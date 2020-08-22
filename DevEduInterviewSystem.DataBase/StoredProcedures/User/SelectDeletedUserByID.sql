CREATE PROCEDURE [dbo].[SelectDeletedUserByID]
@ID int
AS
SELECT * FROM [dbo].[User] WHERE (@ID = ID) AND (IsDeleted = 1)