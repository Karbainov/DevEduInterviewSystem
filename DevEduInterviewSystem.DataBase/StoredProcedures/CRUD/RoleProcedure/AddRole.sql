CREATE PROCEDURE [dbo].[AddRole]
@TypeOfRole nvarchar(30) null
AS
INSERT INTO [dbo].[Role]
VALUES (@TypeOfRole)