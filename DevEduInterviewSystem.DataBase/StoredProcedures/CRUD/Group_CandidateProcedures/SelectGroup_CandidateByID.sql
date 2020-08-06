Create Procedure dbo.[SelectGroup_CandidateByID]
@ID int
AS
Select * From dbo.[Group_Candidate] where (@ID = ID)