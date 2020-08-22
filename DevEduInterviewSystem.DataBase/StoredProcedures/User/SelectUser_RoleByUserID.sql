CREATE PROCEDURE [dbo].[SelectUser_RoleByUserID]
@ID int 
AS
Select * From [dbo].[User_Role] where (@ID = UserID)
