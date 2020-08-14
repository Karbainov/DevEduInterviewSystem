Create Procedure [dbo].[UpdateOneTimePasswordByID]
@ID int,
@CandidateID int,
@DateOfPasswordIssue datetime2,
@OneTimePassword int
AS
BEGIN
UPDATE [dbo].[OneTimePassword]
SET
CandidateID = @CandidateID,
DateOfPasswordIssue = @DateOfPasswordIssue,
OneTimePassword = @OneTimePassword
where (ID = @ID)
end

