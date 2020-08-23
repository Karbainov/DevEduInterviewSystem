CREATE PROCEDURE [dbo].[AddRole]
@TypeOfRole nvarchar(30)
AS
INSERT INTO [dbo].[Role]
VALUES (@TypeOfRole)