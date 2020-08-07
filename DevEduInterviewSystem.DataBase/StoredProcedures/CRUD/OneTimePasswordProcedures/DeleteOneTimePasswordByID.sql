Create Procedure [dbo].[DeleteOneTimePasswordByID]
@ID int
AS
Delete from [dbo].[OneTimePassword] where (@ID = ID)
