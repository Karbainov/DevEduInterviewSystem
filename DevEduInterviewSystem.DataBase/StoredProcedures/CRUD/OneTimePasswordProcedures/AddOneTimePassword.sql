Create Procedure [dbo].[AddOneTimePassword]
@CandidateID int,
@OneTimePasswordDate datetime2,
@OneTimePassword int
AS
INSERT INTO [dbo].[OnetimePassword]
VALUES (@CandidateID, @OneTimePasswordDate, @OneTimePassword)
