CREATE TABLE [dbo].[StageChanged]
(
	[ID] INT PRIMARY KEY IDENTITY,
	[CandidateID] int NULL FOREIGN KEY (CandidateID) REFERENCES [dbo].[Candidate]([ID]),						
	[StageID] int NULL FOREIGN KEY (StageID) REFERENCES [dbo].[Stage]([ID]),
	[ChangedDate] datetime2 NULL,
)
