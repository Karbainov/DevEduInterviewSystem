CREATE PROCEDURE [dbo].[AllInterviewsByDateInterval]
@StartDateTimeInterview datetime2,
@FinishDateTimeInterview datetime2
AS
SELECT U.[FirstName] AS [UserFirstName], U.[LastName] AS [UserLastName], C.[ID] AS [CandidateID],
C.[FirstName] AS [CandidateFirstName], C.[LastName] AS [CandidateLastName], C.[Phone] AS [CandidatePhone], 
I.[DateTimeInterview], I.[Attempt], ISt.[Name] AS [Status]
FROM [dbo].[Interview] AS I
Join [dbo].[User_Interview]  UI On UI.[InterviewID] = I.[ID]
Join [dbo].[User] AS U On UI.[UserID] = U.[ID]
Join [dbo].[Candidate] AS C On I.[CandidateID] = C.[ID]
Join [dbo].[InterviewStatus] AS ISt On I.[InterviewStatusID] = ISt.[ID]
WHERE I.[DateTimeInterview] >= @StartDateTimeInterview AND I.[DateTimeInterview] <= @FinishDateTimeInterview
ORDER BY I.[DateTimeInterview]