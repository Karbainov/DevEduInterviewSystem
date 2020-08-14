CREATE PROCEDURE [dbo].[AllOverdueHomeworks]
@DateCurrent datetime2
AS
	SELECT  HW.[CandidateID], HW.[HomeworkDate], C.[FirstName], C.[LastName], HS.[Name] 
	FROM [dbo].[Homework] AS HW

	INNER JOIN dbo.[Candidate] AS C ON HW.[CandidateID] = C.[ID]
	INNER JOIN dbo.[HomeWorkStatus] AS HS ON HW.[HomeWorkStatusID] = HS.[ID]
	
	where HW.[HomeWorkStatusID] =  2 and HW.[HomeworkDate] > @DateCurrent