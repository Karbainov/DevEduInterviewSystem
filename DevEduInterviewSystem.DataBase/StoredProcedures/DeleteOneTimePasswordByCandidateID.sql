CREATE PROCEDURE [dbo].[DeleteOneTimePasswordByCandidateID]
@ID int
AS
DELETE FROM [dbo].[OneTimePassword] WHERE (@ID = CandidateID)