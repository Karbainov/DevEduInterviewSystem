CREATE PROCEDURE [dbo].[SelectionProcessByCourse] 
@CourseID int
AS
SELECT [Course].[Name] as Course, C.FirstName as CandidateFirstName, C.LastName as CandidateLastName, S.[Name] as [Status], St.[Name] as Stage

FROM [dbo].[Candidate] as C 
JOIN [dbo].[Status] as S on C.StatusID = S.ID
JOIN [dbo].[Stage] as St on C.StageID = St.ID
LEFT JOIN [dbo].Course_Candidate as CsCd on C.ID = CsCd.CandidateID
LEFT JOIN [dbo].Course on CsCd.CourseID = Course.ID
WHERE  Course.ID = @CourseID
