CREATE PROCEDURE [dbo].[SelectCourse_CandidateByID]
	@ID int 
AS
Select  * From [dbo].[Course_Candidate] 
where (@ID = ID)