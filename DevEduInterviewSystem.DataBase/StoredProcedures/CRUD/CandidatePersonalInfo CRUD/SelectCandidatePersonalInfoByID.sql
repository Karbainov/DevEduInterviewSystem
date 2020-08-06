Create Procedure dbo.[SelectCandidatePersonalInfoByID]
@ID int
AS
Select * From dbo.[CandidatePersonalInfo] where (@ID = ID)