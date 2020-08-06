CREATE PROCEDURE [dbo].[DeleteTaskByID]
@ID int 
AS
Delete from [dbo].[Task] where (@ID = ID)
