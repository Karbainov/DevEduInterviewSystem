Create Procedure  [dbo].[AllFeedbacksByUser]
@UserID  int 
as
select U.[ID] as [UserID], U.[FirstName] as [UserFirstName], U.[LastName] as [UserLastName], Fb.[Message], Fb.[TimeFeedback],
       C.FirstName as [CandidateFirstName], C.LastName as [CandidateLastName]
From dbo.[Feedback] as Fb
JOIN dbo.[User] as U on Fb.[UserID] = U.[ID]
JOIN dbo.[StageChanged] as SC on SC.[ID] = Fb.[StageChangedID]
JOIN dbo.[Candidate] as C on C.[ID] = SC.[CandidateID]
where @UserId = Fb.[UserID]