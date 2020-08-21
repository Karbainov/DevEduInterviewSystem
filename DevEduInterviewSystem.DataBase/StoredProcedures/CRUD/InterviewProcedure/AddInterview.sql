Create Procedure [dbo].[AddInterview]
@CandidateID int null,
@InterviewStatusID int null,
@Attempt int null,
@DateTimeInterview datetime2 null
AS
INSERT INTO [dbo].[Interview]
VALUES (@CandidateID, @InterviewStatusID, @Attempt, @DateTimeInterview)
--SELECT SCOPE_IDENTITY()

