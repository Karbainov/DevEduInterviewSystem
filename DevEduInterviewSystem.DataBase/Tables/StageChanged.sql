CREATE TABLE [dbo].[StageChanged]
(
	[Id] INT NOT NULL PRIMARY KEY,
	CandidateID int NULL FOREIGN KEY (CandidateID) REFERENCES [dbo].[Candidate]([ID]),						
	StageID int NULL FOREIGN KEY (StageID) REFERENCES [dbo].[Stage]([ID]),
	[ChangedDate] datetime2 NULL,
)
