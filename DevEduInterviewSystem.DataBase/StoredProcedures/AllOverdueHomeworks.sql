CREATE PROCEDURE [dbo].[AllOverdueHomeworks] 
@DateCurrent datetime2	
AS
SELECT HW.[HomeworkDate], C.[FirstName] as [CandidateFirstName], C.[LastName] as [CandidateLastName], HSt.[Name] as [HomeworkStatusName]
FROM dbo.[Homework] as HW
JOIN dbo.[Candidate] as C on HW.[CandidateID] = C.[ID]
JOIN dbo.[HomeworkStatus] as HSt on HW.[HomeworkStatusID] = HSt.[ID]

