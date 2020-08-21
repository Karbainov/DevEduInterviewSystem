CREATE TABLE [dbo].[StageChanged]
(
	[ID] INT PRIMARY KEY IDENTITY,
	[CandidateID] int FOREIGN KEY (CandidateID) REFERENCES [dbo].[Candidate]([ID]) NULL,						
	[StageID] int FOREIGN KEY (StageID) REFERENCES [dbo].[Stage]([ID]) NULL,
	[ChangedDate] datetime2 NULL,
)
