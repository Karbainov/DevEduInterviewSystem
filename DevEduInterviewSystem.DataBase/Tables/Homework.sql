CREATE TABLE [dbo].[Homework]
(

	ID int Primary key Identity,
	CandidateID int FOREIGN KEY ([CandidateID]) REFERENCES [Candidate]([ID]) NULL,
	HomeworkStatusID int FOREIGN KEY ([HomeworkStatusID]) REFERENCES [HomeworkStatus]([ID]) NULL,
	TestStatusID int NULL,
	HomeworkDate datetime2 NULL
	

)
