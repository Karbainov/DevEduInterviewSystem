Create Procedure [dbo].[SelectAllUser] AS
Select * From [dbo].[User]
WHERE IsDeleted = 0
