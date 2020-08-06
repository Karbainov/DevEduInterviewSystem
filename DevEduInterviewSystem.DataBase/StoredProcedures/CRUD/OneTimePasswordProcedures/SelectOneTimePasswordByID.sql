Create Procedure [dbo].[SelectOneTimePasswordByID]
@ID int
AS
Select * From [dbo].[OneTimePassword] where (@ID = ID)
