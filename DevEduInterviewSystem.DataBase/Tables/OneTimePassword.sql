CREATE TABLE [dbo].[OneTimePassword]
(
	[ID] INT PRIMARY KEY Identity,
	[CandidateID] INT NULL FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID]),
	[DateOfPasswordIssue] DATETIME2 NULL,
	[OneTimePassword]  NVARCHAR(50) NULL
 )

