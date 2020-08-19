CREATE PROCEDURE [dbo].[AllStudentsOfGroup]
@GroupID int
AS
	SELECT G.[Name], C.FirstName, C.LastName
	FROM Group_Candidate AS GC
	JOIN [Group] AS G ON G.[ID] = GC.GroupID
	JOIN  Candidate AS C ON C.ID = GC.CandidateID 
	
	Where G.ID = @GroupID