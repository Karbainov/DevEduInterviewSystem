CREATE PROCEDURE [dbo].[DeleteRoleByID]
@ID int 
AS
Delete from [dbo].[Role] where (@ID = ID)
