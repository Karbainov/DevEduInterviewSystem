CREATE TABLE [dbo].[OneTimePassword]
(
	[ID] INT PRIMARY KEY Identity,
	[CandidateID] INT FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID]) NULL,
	[DateOfPasswordIssue] DATETIME2 NULL,
	[OneTimePassword]  NVARCHAR(50) NULL
 )

