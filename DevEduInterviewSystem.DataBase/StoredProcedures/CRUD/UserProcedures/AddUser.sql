Create Procedure [dbo].[AddUser]
@Login nvarchar (30),
@Password nvarchar (30),
@FirstName nvarchar (30),
@LastName nvarchar (30),
@IsDeleted bit = 0
AS
INSERT INTO [dbo].[User]
VALUES (@Login, @Password, @FirstName, @LastName, @IsDeleted)
SELECT SCOPE_IDENTITY()