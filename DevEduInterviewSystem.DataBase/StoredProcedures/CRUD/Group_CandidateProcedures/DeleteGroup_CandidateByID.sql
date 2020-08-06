Create Procedure dbo.[DeleteGroup_CandidateByID]
@ID int
AS
Delete From dbo.[Group_Candidate]
Where (@ID = ID)