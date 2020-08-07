CREATE PROCEDURE [dbo].[DeleteCourse_CandidateByID]
	@ID int 
AS
Delete from [dbo].[Course_Candidate] 
where (@ID = ID)