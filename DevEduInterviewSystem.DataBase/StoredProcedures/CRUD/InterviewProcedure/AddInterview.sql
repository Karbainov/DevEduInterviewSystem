Create Procedure [dbo].[AddInterview]
@CandidateID int,
@InterviewStatusID int,
@Attempt int,
@DateTimeInterview datetime2
AS
INSERT INTO [dbo].[Interview]
VALUES (@CandidateID, @InterviewStatusID, @Attempt, @DateTimeInterview)

