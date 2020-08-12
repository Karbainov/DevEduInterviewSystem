CREATE PROCEDURE [dbo].[AllInterviewsByUser]
@UserID int
AS
Select U.[FirstName] AS [UserFirstName], U.[LastName] AS [UserLastName], C.[ID] AS [CandidateID], C.[FirstName] AS [CandidateFirstName], C.[LastName] AS [CandidateLastName], C.[Phone] AS [CandidatePhone], I.[DateTimeInterview], I.[Attempt], ISt.[Name] AS [Status]
From [dbo].[Interview] as I
Join [dbo].[User_Interview] as UI On UI.[InterviewID] = I.[ID]
Join [dbo].[User] as U On UI.[UserID] = U.[ID]
Join [dbo].[Candidate] as C On I.[CandidateID] = C.[ID]
Join [dbo].[InterviewStatus] as ISt On I.[InterviewStatusID] = ISt.[ID]
Where U.[ID] = @UserID
