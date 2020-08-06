CREATE PROCEDURE [dbo].[AddFeedback]
@StageChangedID int,
@UserID int,
@Message nvarchar(2500),
@TimeFeedback datetime2 
as
begin
INSERT INTO [dbo].[Feedback]
VALUES (@StageChangedID, @UserID, @Message, @TimeFeedback)
end
