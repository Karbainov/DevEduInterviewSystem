CREATE PROCEDURE [dbo].[AddHomework]
@CandidateID int,
@HomeworkStatusID int,
@Attempt int,
@HomeworkDate datetime2
AS
BEGIN
INSERT INTO [dbo].[Homework]
VALUES (@CandidateID, @HomeworkStatusID, @Attempt, @HomeworkDate)
end
