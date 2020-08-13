CREATE PROCEDURE [dbo].[AllTasksByUser]
@UserID int
AS
SELECT U.[FirstName] AS [UserFirstName], U.[LastName] AS [UserLastName], 
C.[ID] AS [CandidateID], C.[FirstName] AS [CandidateFirstName], C.[LastName] AS [CandidateLastName], 
T.[Message] AS [Task], T.[IsCompleted], S.[Name] AS [Stage]
FROM dbo.[USER] AS U
JOIN dbo.[Task] AS T ON U.[ID] = T.[UserID]
JOIN dbo.[Candidate] AS C ON T.[CandidateID] = C.[ID]
JOIN dbo.[Stage] AS S ON C.[StageID] = S.[ID]
WHERE U.[ID] = @UserID

