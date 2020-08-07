CREATE PROCEDURE [dbo].[AllInterviewsByUser]
@UserID int
AS
Select * From [Interview]
Join [User_Interview] On [User_Interview].InterviewID = [Interview].ID
Join [User] On [User_Interview].UserID = [User].ID
Join [Candidate] On [Interview].CandidateID = [Candidate].ID
Join [InterviewStatus] On [Interview].InterviewStatusID = [InterviewStatus].ID
Where [User].ID = @UserID
