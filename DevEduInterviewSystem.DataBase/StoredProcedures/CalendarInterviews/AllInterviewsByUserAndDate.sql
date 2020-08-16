CREATE PROCEDURE [dbo].[AllInterviewsByUserAndDate]
@UserID int,
@DateTimeInterview datetime2
AS

Select U.[FirstName], U.[LastName], C.[ID], C.[FirstName], C.[LastName], C.[Phone], I.[Attempt], I.[DateTimeInterview], ISt.[Name] 
From [dbo].[Interview] as I
Join [dbo].[User_Interview] as UI On UI.[InterviewID] = I.[ID]
Join [dbo].[User] as U On UI.[UserID] = U.[ID]
Join [dbo].[Candidate] as C On I.[CandidateID] = C.[ID]
Join [dbo].[InterviewStatus] as ISt On I.[InterviewStatusID] = ISt.[ID]
Where [User].ID = @UserID and [Interview].DateTimeInterview = @DateTimeInterview

Select U.[FirstName] AS [UserFirstName], U.[LastName] AS [UserLastName], C.[ID] AS [CandidateID],
C.[FirstName] AS [CandidateFirstName], C.[LastName] AS [CandidateLastName], C.[Phone] AS [CandidatePhone], 
I.[DateTimeInterview], I.[Attempt], ISt.[Name] AS [Status]
FROM [Interview] AS I
Join [User_Interview] AS UI ON UI.[InterviewID] = I.[ID]
Join [User] AS U ON UI.[UserID] = U.[ID]
Join [Candidate] AS C ON I.[CandidateID] = C.[ID]
Join [InterviewStatus] AS ISt ON I.[InterviewStatusID] = ISt.[ID]
WHERE U.[ID] = @UserID AND U.IsDeleted = 0 AND I.[DateTimeInterview] = @DateTimeInterview
ORDER BY C.[ID]


