CREATE PROCEDURE [dbo].[UpdateTaskByID]
@ID int,
@UserID int,
@CandidateID int,
@Message nvarchar (2500),
@IsComplited bit
AS
BEGIN
UPDATE [dbo].[Task]
SET UserID = @UserID,
CandidateID = @CandidateID ,
Message = @Message,
IsComplited = @IsComplited 
where (@ID = ID)
end
