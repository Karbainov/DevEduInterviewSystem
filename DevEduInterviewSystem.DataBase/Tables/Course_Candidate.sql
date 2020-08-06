CREATE TABLE [dbo].[Course_Candidate] ( 
	ID int NOT NULL PRIMARY KEY IDENTITY, 
	[CourseID] int NOT NULL FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course]([ID]),
	CandidateID int NOT NULL FOREIGN KEY (CandidateID) REFERENCES [dbo].[Candidate]([ID])
)