Create Procedure dbo.[SelectGroupByID]
@ID int
AS
Select * From dbo.[Group] where (@ID = ID)