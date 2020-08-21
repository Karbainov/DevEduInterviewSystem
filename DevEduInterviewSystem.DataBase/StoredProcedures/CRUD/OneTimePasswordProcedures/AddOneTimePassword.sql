Create Procedure [dbo].[AddOneTimePassword]
@CandidateID int null,
@DateOfPasswordIssue datetime2 null,
@OneTimePassword int null
AS
INSERT INTO [dbo].[OnetimePassword]
VALUES (@CandidateID, @DateOfPasswordIssue, @OneTimePassword)
