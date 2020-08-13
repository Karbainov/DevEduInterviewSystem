CREATE PROCEDURE [dbo].[AllStudentsOfGroupByStart]
@StartDate datetime
AS
	SELECT G.[Name], G.StartDate, C.FirstName, C.LastName
	FROM Group_Candidate AS GC
JOIN  Candidate AS C ON C.ID = GC.CandidateID 
JOIN [Group] AS G ON G.[ID] = GC.GroupID
	WHERE G.StartDate = @StartDate