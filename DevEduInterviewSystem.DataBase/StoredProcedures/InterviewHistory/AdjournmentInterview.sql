CREATE PROCEDURE [dbo].[AdjournmentInterview] AS

	SELECT I.CandidateID, C.FirstName, C.LastName, ISt.[Name] FROM Interview AS I
	JOIN Candidate AS C ON C.ID = I.CandidateID
	JOIN InterviewStatus AS ISt ON ISt.[Name] = I.InterviewStatusID
	WHERE ISt.[Name] = 'Перенес'
	

