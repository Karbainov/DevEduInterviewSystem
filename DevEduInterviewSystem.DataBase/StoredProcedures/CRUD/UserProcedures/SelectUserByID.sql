CREATE PROCEDURE [dbo].[SelectUserByID]
@ID int
AS
Select * From [dbo].[User] where (@ID = ID) AND (IsDeleted = 0)