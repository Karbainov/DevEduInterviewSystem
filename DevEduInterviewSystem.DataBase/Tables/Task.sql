CREATE TABLE [dbo].[Task]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserID] INT  NULL FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([ID]),
	[CandidateID] INT NULL FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID]),
	[Message] NVARCHAR (2500) NULL,
	[IsCompleted] NVARCHAR(50)  NULL
)	


