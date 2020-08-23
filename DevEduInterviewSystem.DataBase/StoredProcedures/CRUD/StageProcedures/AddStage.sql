CREATE PROCEDURE [dbo].[AddStage]
@Name nvarchar(30)
as

insert into [dbo].[Stage]
values (@Name)
--SELECT SCOPE_IDENTITY()
