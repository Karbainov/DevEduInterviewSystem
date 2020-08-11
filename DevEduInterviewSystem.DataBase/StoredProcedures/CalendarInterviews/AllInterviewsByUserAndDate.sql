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

