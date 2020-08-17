CREATE PROCEDURE [dbo].[AllOverdueHomework]
@DateCurrent datetime2
AS
	SELECT  HW.[CandidateID], HW.[HomeWorkDate], C.[FirstName] AS CandidateFirstName, C.[LastName] AS CandidateLastName, HS.[Name] AS [HomeWorkStatus], TS.[Name] AS [TestStatus]
	FROM [dbo].[Homework] AS HW

	JOIN dbo.[Candidate] AS C ON HW.[CandidateID] = C.[ID]
	JOIN dbo.[HomeWorkStatus] AS HS ON HW.[HomeWorkStatusID] = HS.[ID]
	JOIN dbo.[TestStatus] AS TS ON HW.[TestStatusID] = TS.[ID]
	
	WHERE HW.[HomeWorkStatusID] =  2 or HW.[TestStatusID] = 2 and HW.[HomeWorkDate] > @DateCurrent