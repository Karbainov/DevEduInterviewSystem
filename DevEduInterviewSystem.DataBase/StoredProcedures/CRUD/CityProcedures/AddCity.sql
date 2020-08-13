CREATE PROCEDURE [dbo].[AddCity]
	@City nvarchar(30)
AS
INSERT INTO [dbo].[City]
VALUES (@City)
  SELECT SCOPE_IDENTITY()

