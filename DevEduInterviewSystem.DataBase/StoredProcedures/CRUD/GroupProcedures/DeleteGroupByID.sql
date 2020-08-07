Create Procedure dbo.[DeleteGroupByID]
@ID int
AS
Delete from dbo.[Group] where (@ID = ID)