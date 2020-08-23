CREATE PROCEDURE [dbo].[AddCity]
	@Name nvarchar(30),
	@IsDeleted bit = 0
AS
BEGIN
INSERT INTO [dbo].[City]
VALUES (@Name, @IsDeleted)
END

