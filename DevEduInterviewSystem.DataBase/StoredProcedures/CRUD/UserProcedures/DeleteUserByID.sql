CREATE PROCEDURE [dbo].[DeleteUserByID]
@ID int
AS
Delete from [dbo].[User] where (@ID = ID)
