CREATE PROCEDURE [dbo].[SelectRoleByID]
@ID int 
AS
Select  * From [dbo].[Role] where (@ID = ID)