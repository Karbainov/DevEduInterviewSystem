CREATE PROCEDURE [dbo].[AllOverdueHomework]
@DateCurrent datetime2
AS
	SELECT  HW.[CandidateID], HW.[HomeworkDate], C.[FirstName], C.[LastName], HS.[Name] AS [HomeWorkStatus], TS.[Name] AS [TestStatus]
	FROM [dbo].[Homework] AS HW

	INNER JOIN dbo.[Candidate] AS C ON HW.[CandidateID] = C.[ID]
	INNER JOIN dbo.[HomeWorkStatus] AS HS ON HW.[HomeWorkStatusID] = HS.[ID]
	INNER JOIN dbo.[TestStatus] AS TS ON HW.[TestStatusID] = TS.[ID]
	
	WHERE HW.[HomeWorkStatusID] =  2 or HW.[TestStatusID] = 2 and HW.[HomeworkDate] > @DateCurrent