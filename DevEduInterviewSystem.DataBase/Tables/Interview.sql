CREATE TABLE [dbo].[Interview] (
	[ID] int Primary key Identity,
	[CandidateID] int FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID]) NULL,
	[InterviewStatusID] int FOREIGN KEY ([InterviewStatusID]) REFERENCES [dbo].[InterviewStatus]([ID]) NULL,
	[Attempt] int NULL,
	[DateTimeInterview] datetime2 NULL,
 )
