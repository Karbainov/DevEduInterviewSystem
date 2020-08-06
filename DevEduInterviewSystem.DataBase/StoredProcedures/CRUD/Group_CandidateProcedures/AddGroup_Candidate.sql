Create Procedure dbo.[AddGroup_Candidate]
@GroupID int,
@CandidateID int
AS
INSERT INTO dbo.[Group_Candidate]
VALUES (@GroupID, @CandidateID)