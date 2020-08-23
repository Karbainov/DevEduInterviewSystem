Create Procedure dbo.[SelectAllGroup]
AS
Select * From dbo.[Group]
WHERE IsDeleted=0