Create Procedure [dbo].[UpdateInterviewByID]
@ID int,
@CandidateID int,
@InterviewStatusID int,
@Attempt int,
@DateTimeInterview datetime2
AS

UPDATE [dbo].[Interview]
SET CandidateID = @CandidateID,
InterviewStatusID = @InterviewStatusID,
Attempt = @Attempt,
DateTimeInterview = @DateTimeInterview
where (@ID = ID)

