CREATE PROCEDURE [dbo].[UpdateFeedbackByID]
@ID int,
@StageChangedID int,
@UserID int,
@Message nvarchar(2500),
@TimeFeedback datetime2 	
as
begin
Update dbo.[Feedback]

set StageChangedID = @StageChangedID,
UserID = @UserID,
[Message] = @Message,
TimeFeedback  = @TimeFeedback
	
where (ID = @ID)
end