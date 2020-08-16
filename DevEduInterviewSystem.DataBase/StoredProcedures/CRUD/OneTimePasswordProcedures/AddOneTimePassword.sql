Create Procedure [dbo].[AddOneTimePassword]
@CandidateID int,
@DateOfPasswordIssue datetime2,
@OneTimePassword int
AS
INSERT INTO [dbo].[OnetimePassword]
VALUES (@CandidateID, @DateOfPasswordIssue, @OneTimePassword)
