CREATE TABLE [dbo].[Interview] (
	ID int Primary key Identity,
	CandidateID int NULL, --FOREIGN KEY ([CandidateID]) REFERENCES [Candidate]([ID])
	InterviewStatusID int NULL, --FOREIGN KEY ([InterviewStatusID]) REFERENCES [InterviewStatus]([ID])
	Attempt int NULL,
	DateTimeInterview datetime2 NULL,
 )
