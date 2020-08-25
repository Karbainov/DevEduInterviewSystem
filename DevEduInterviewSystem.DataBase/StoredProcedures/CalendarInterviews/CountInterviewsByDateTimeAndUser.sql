CREATE PROCEDURE [dbo].[CountInterviewsByDateTimeAndUser]
@UserID int,
@DateTimeInterview datetime2
AS
Select Count(I.ID) AS count 
FROM [Interview] AS I
Join [User_Interview] AS UI ON UI.[InterviewID] = I.[ID]
Join [User] AS U ON UI.[UserID] = U.[ID]
WHERE U.[ID] = @UserID AND U.IsDeleted = 0 AND I.[DateTimeInterview] = @DateTimeInterview
