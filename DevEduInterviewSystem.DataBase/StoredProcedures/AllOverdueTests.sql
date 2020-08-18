CREATE PROCEDURE [dbo].[AllOverdueTests] 
@DateCurrent datetime2
AS
SELECT HW.[HomeworkDate] as [HomeworkDate], C.[FirstName] as [CandidateFirstName], C.[LastName] as [CandidateLastName], TSt.[Name] as [TestStatusName]
FROM [dbo].[Homework] as HW
JOIN [dbo].[Candidate] as C on HW.[CandidateID] = C.[ID]
JOIN [dbo].[TestStatus] as TSt on HW.[HomeworkStatusID] = TSt.[ID]