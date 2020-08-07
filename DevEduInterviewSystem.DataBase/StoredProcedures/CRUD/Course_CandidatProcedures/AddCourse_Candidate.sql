CREATE PROCEDURE [dbo].[AddCourse_Candidate]
	@CourseID int,
	@CandidateID int
AS
INSERT INTO [dbo].[Course_Candidate]
VALUES (@CourseID, @CandidateID)
