Create Procedure dbo.[UpdateGroup_CandidateByID]
@ID int,
@GroupID int,
@CandidateID int
AS
UPDATE dbo.[Group_Candidate]
SET 
GroupID = @GroupID,
CandidateID = @CandidateID
where (@ID = ID)