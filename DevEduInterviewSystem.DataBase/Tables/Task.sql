CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY,
	UserID int NULL, --FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
	CandidateID int NULL, -- FOREIGN KEY ([CandidateID]) REFERENCES [Candidate]([ID])
	Message nvarchar(2500) NULL,
	IsComplited bit NULL,
)	

