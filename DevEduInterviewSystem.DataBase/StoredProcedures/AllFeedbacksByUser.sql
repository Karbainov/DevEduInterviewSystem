Create Procedure  [dbo].[AllFeedbackByUser]
@UserID  int 
as
select U.[ID] as [UserID], U.[FirstName] as [UserFirstName], U.[LastName] as [UserLastName], Fb.[Message], Fb.[TimeFeedback] 
From dbo.[Feedback] as Fb
JOIN dbo.[User] as U on Fb.[UserID] = U.[ID]
where @UserId = Fb.[UserID]