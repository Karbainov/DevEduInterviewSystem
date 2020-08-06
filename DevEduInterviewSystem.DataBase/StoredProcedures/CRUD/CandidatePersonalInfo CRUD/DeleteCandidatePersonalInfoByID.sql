Create Procedure dbo.[DeleteCandidatePersonalInfoByID]
@ID int
AS
Delete from dbo.[CandidatePersonalInfo] where (@ID = ID)
