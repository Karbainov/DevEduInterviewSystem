﻿CREATE PROCEDURE [dbo].[AllInterviews]
AS
SELECT U.[FirstName] AS [UserFirstName], U.[LastName] AS [UserLastName], U.[Login] AS [UserLogin],
C.[ID] AS [CandidateID], C.[FirstName] AS [CandidateFirstName], C.[LastName] AS [CandidateLastName],
C.[Phone] AS [CandidatePhone], I.[DateTimeInterview],I.[Attempt], ISt.[Name] AS [InterviewStatus]
FROM [dbo].[Interview] AS I
Join [dbo].[User_Interview] AS UI ON UI.[InterviewID] = I.[ID]
Join [dbo].[User] AS U ON UI.[UserID] = U.[ID]
Join [dbo].[Candidate] AS C ON I.[CandidateID] = C.[ID]
Join [dbo].[InterviewStatus] AS ISt ON I.[InterviewStatusID] = ISt.[ID]
ORDER BY C.[ID]
