CREATE PROCEDURE [dbo].[AllCandidateOfAllCourses]
AS
	SELECT Course.[Name], C.FirstName, C.LastName
	FROM [dbo].[Course_Candidate]
	JOIN  Candidate AS C ON C.ID = Course_Candidate.CandidateID 
	JOIN Course ON Course.ID = Course_Candidate.CourseID
