Create Procedure [dbo].[AddUser]
@Login nvarchar (30),
@Password nvarchar (30),
@FirstName nvarchar (30),
@LastName nvarchar (30)
AS
INSERT INTO [dbo].[User]
VALUES (@Login, @Password, @FirstName, @LastName)
