CREATE PROCEDURE [dbo].[AddStatus]
@Name nvarchar(30)
as
INSERT INTO [dbo].[Status]
VALUES (@Name)