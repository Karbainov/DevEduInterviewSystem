CREATE PROCEDURE [dbo].[DeleteUser_RoleByID]
@ID int 
AS
Delete from [dbo].[User_Role] where (@ID = ID)
