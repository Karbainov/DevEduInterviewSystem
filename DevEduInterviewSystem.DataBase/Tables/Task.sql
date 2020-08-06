CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY
	UserID int NULL,
	CandidateID int NULL,
	Message nvarchar(2500) NULL,
	IsCompleted bit NULL,
)	
GO
ALTER TABLE [dbo].[Task] WITH CHECK ADD CONSTRAINT [dbo].[Task_fk0] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [Task_fk0]
GO
ALTER TABLE [dbo].[Task] WITH CHECK ADD CONSTRAINT [Task_fk1] FOREIGN KEY ([CandidateID]) REFERENCES [Candidate]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [Task_fk1]
GO

