Create Procedure [dbo].[UpdateOneTimePasswordByID]
@ID int,
@CandidateID int,
@OneTimePasswordDate datetime2,
@OneTimePassword int
AS
BEGIN
UPDATE [dbo].[OneTimePassword]
SET
CandidateID = @CandidateID,
OneTimePasswordDate = @OneTimePasswordDate,
OneTimePassword = @OneTimePassword
where (ID = @ID)
end
