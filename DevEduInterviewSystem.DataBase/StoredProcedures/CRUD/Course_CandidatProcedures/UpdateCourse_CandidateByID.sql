CREATE PROCEDURE [dbo].[UpdateCourse_CandidateByID]
	@ID int,
	@CourseID int,
	@CandidateID int
AS
BEGIN
	UPDATE [dbo].[Course_Candidate]
SET 
	CourseID = @CourseID,
	CandidateID = @CandidateID
where (@ID = ID)
end