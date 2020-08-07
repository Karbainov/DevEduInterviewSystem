CREATE TABLE [dbo].[Course_Candidate] ( 
	[ID] int NOT NULL PRIMARY KEY IDENTITY, 
	[CourseID] int NULL FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course]([ID]),
	[CandidateID] int NULL FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID])
)