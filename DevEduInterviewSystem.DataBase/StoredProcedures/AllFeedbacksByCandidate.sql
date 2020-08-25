CREATE PROCEDURE [dbo].[AllFeedbacksByCandidate]
@CandidateID int
AS
SELECT 
C.[ID] as [CandidateID], C.[FirstName] as [CandidateFirstName], C.[LastName] as [CandidateLastName],
U.[FirstName] as [UserFirstName], U.[LastName] as [UserLastName],
S.[Name] as [StageName],
Fb.[Message] as [FeedBackMessage], Fb.[TimeFeedback] as [TimeFeedback]

FROM dbo.[Candidate] as C

LEFT JOIN dbo.[StageChanged] as SC on SC.[CandidateID] = C.[ID]
JOIN dbo.[Stage] as S on S.[ID] = SC.[StageID]
JOIN dbo.[Feedback] as Fb on SC.ID = Fb.[StageChangedID]
JOIN dbo.[User] as U on U.[ID] = Fb.[UserID]

WHERE C.[ID] = @CandidateID

/*FROM dbo.[Feedback] as Fb
JOIN dbo.[User] as U on U.[ID] = Fb.[UserID]
JOIN dbo.[StageChanged] as SC on SC.[ID] = Fb.[StageChangedID]
JOIN dbo.[Stage] as S on SC.[StageID] = S.[ID]		
JOIN dbo.Candidate as C on SC.[CandidateID] = C.[ID]] */

