CREATE PROCEDURE [dbo].[UpdateHomeworkByID]
@ID int,
@CandidateID int,
@HomeworkStatusID int,
@TestStatusID int,	
@HomeworkDate datetime2


AS
BEGIN
Update [dbo].[Homework]

set CandidateID = @CandidateID,
HomeworkStatusID = @HomeworkStatusID,
TestStatusID  = @TestStatusID,
HomeworkDate = @HomeworkDate

	
where (ID = @ID)
END