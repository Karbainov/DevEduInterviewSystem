CREATE TABLE [dbo].[Task]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserID] INT  NULL FOREIGN KEY ([UserID]) REFERENCES [User]([ID],
	[CandidateID] INT NULL FOREIGN KEY ([CandidateID]) REFERENCES [Candidate]([ID]),
	[Message] NVARCHAR (2500) NULL,
	[IsCompleted] BIT  NULL,
)	


