CREATE PROCEDURE [dbo].[SelectAllCity]
AS
Select * From [dbo].[City]
WHERE IsDeleted=0