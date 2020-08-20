CREATE PROCEDURE [dbo].[DeleteCandidateFromCourseCandidateByCandidateID]
@ID int 
AS
Delete FROM [dbo].[Course_Candidate] 
WHERE (@ID = CandidateID)