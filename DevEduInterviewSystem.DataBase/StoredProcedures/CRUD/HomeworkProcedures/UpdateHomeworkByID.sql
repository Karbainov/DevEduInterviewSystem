CREATE PROCEDURE [dbo].[UpdateHomeworkByID]
@ID int,
@CandidateID int,
@HomeworkStatusID int,
@HomeworkDate datetime2,
@TestStatusID int	

AS
BEGIN
Update [dbo].[Homework]

set CandidateID = @CandidateID,
HomeworkStatusID = @HomeworkStatusID,
HomeworkDate = @HomeworkDate,
TestStatusID  = @TestStatusID
	
where (ID = @ID)
END