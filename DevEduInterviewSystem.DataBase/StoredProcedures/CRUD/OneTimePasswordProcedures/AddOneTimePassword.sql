Create Procedure [dbo].[AddOneTimePassword]
@CandidateID int,
@DateOfPasswordIssue datetime2,
@OneTimePassword nvarchar (50)
AS
INSERT INTO [dbo].[OnetimePassword]
VALUES (@CandidateID, @DateOfPasswordIssue, @OneTimePassword)
