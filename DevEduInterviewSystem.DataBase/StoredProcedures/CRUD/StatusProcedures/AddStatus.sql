CREATE PROCEDURE [dbo].[AddStatus]
@Name nvarchar(30)
as
begin
INSERT INTO [dbo].[Status]
VALUES (@Name )
end
