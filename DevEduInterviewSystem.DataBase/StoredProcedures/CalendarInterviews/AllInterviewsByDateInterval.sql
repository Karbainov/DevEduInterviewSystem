CREATE PROCEDURE [dbo].[AllInterviewsByDateInterval]
@StartDateTimeInterview datetime2,
@FinishDateTimeInterview datetime2
AS
Select * From [dbo].[Interview]
Join [User_Interview] On [User_Interview].InterviewID = [Interview].ID
Join [User] On [User_Interview].UserID = [User].ID
Join [Candidate] On [Interview].CandidateID = [Candidate].ID
Join [InterviewStatus] On [Interview].InterviewStatusID = [InterviewStatus].ID
Where [Interview].DateTimeInterview >= @StartDateTimeInterview and  [Interview].DateTimeInterview <= @FinishDateTimeInterview