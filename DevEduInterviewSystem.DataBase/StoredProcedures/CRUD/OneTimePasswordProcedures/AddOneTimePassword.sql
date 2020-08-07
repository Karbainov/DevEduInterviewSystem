Create Procedure [dbo].[AddOneTimePassword]
@CandidateID int,
@OneTimePasswordDate datetime2,
@OneTimePassword int
AS
INSERT INTO [dbo].[AddOnetimePassword]
VALUES (@CandidateID, @OneTimePasswordDate, @OneTimePassword)
