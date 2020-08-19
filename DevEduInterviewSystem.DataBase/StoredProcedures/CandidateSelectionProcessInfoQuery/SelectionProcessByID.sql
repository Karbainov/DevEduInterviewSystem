CREATE PROCEDURE [dbo].[SelectionProcessByID] 
@CandidateID int
AS
SELECT C.ID as CandidateID, C.FirstName as CandidateFirstName, C.LastName as CandidateLastName, 
       S.[Name] as [Status], St.[Name] as Stage, [Course].[Name] as Course
FROM [dbo].[Candidate] as C 
JOIN [dbo].[Status] as S on C.StatusID = S.ID
JOIN [dbo].[Stage] as St on C.StageID = St.ID
LEFT JOIN [dbo].Course_Candidate as CsCd on C.ID = CsCd.CandidateID
LEFT JOIN [dbo].Course on CsCd.CourseID = Course.ID
WHERE  C.ID = @CandidateID
