CREATE PROCEDURE [dbo].[UpdateUserByID]
@ID int,
@Login nvarchar (30),
@Password nvarchar (30),
@FirstName nvarchar (30),
@LastName nvarchar (30)
AS
BEGIN
UPDATE [dbo].[User]
SET Login = @Login,
Password = @Password,
FirstName = @FirstName,
LastName = @LastName
WHERE (@ID = ID) AND (IsDeleted = 0)
END
