CREATE PROCEDURE [dbo].[AllStudentsOfGroup]
AS
	SELECT G.[Name], C.FirstName, C.LastName
	FROM Group_Candidate AS GC
	JOIN  Candidate AS C ON C.ID = GC.CandidateID 
	JOIN [Group] AS G ON G.[Name] = GC.GroupID
	 