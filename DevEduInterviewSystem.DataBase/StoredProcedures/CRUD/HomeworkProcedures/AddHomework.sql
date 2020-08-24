CREATE PROCEDURE [dbo].[AddHomework]
@CandidateID int,
@HomeworkStatusID int,
@TestStatusID int,
@HomeworkDate datetime2


	
AS
BEGIN
INSERT INTO [dbo].[Homework]
VALUES (@CandidateID, @HomeworkStatusID, @TestStatusID, @HomeworkDate)
end
