CREATE PROCEDURE [dbo].[AddCity]
	@Name nvarchar(30)
AS
INSERT INTO [dbo].[City]
VALUES (@Name)
  SELECT SCOPE_IDENTITY()

