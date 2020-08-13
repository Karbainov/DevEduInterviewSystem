CREATE PROCEDURE [dbo].[AllOverdueHomework]
AS
	SELECT  HW.[CandidateID], HW.[HomeworkDate] FROM [dbo].[Homework] AS HW
	INNER JOIN dbo.[Candidate] AS C ON C.[ID] = HW.[CandidateID]
	INNER JOIN dbo.[HomeWorkStatus] AS HS ON HW.[HomeWorkStatusID] = HS.[ID]
	where HW.[HomeWorkStatusID] = 1
	GROUP BY C.[FirstName], C.[LastName], HS.[Name], HW.[HomeWorkDate]