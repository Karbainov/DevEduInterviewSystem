CREATE PROCEDURE [dbo].[AttemptsInterviewCandidate]
@CandidateID INT
AS
	SELECT C.FirstName, C.LastName, MAX(I.Attempt) 
	FROM Interview AS I 
	INNER JOIN Candidate AS C ON C.ID =	I.CandidateID	
	WHERE I.CandidateID = @CandidateID
	GROUP BY C.FirstName, C.LastName