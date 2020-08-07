CREATE PROCEDURE [dbo].[UpdateTaskByID]
@ID int,
@UserID int,
@CandidateID int,
@Message nvarchar (2500),
@IsCompleted bit
AS
BEGIN
UPDATE [dbo].[Task]
SET UserID = @UserID,
CandidateID = @CandidateID ,
Message = @Message,
IsCompleted = @IsCompleted
where (@ID = ID)
end
