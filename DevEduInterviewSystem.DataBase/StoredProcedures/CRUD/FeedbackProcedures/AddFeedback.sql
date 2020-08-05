CREATE PROCEDURE [dbo].[AddFeedback]
@StageChangedID int,
@UserID int,
@Message nvarchar(2500),
@DateTime datetime2 
as
begin
INSERT INTO [dbo].[Feedback]
VALUES (@StageChangedID, @UserID, @Message, @DateTime)
end
