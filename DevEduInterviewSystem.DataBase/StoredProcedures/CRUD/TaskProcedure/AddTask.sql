CREATE PROCEDURE [dbo].[AddTask]
@UserID int,
@CandidateID int,
@Message nvarchar (2500),
@IsCompleted bit 
AS
INSERT INTO [dbo].[Task]
VALUES (@UserID, @CandidateID, @Message, @IsCompleted)
