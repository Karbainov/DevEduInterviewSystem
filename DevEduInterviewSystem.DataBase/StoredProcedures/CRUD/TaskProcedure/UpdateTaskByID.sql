CREATE PROCEDURE [dbo].[UpdateTaskByID]
@ID int,
@UserID int,
@CandidateID int,
@Message nvarchar (2500),
@IsCompleted nvarchar (50)
AS
BEGIN
UPDATE [dbo].[Task]
SET UserID = @UserID,
CandidateID = @CandidateID ,
Message = @Message,
IsCompleted = @IsCompleted
where (@ID = ID)
end
