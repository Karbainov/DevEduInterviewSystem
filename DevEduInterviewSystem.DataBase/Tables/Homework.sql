CREATE TABLE [dbo].[Homework] 
(  
	ID int Primary key Identity, 
	CandidateID int  NULL FOREIGN KEY ([CandidateID]) REFERENCES [Candidate]([ID]), 
	HomeworkStatusID int NULL FOREIGN KEY ([HomeworkStatusID]) REFERENCES [HomeworkStatus]([ID]) , 
	TestStatusID int NULL, 
	HomeworkDate datetime2 NULL   
) 

	ID int Primary key Identity,
	CandidateID int  NULL FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID]),
	HomeworkStatusID int NULL FOREIGN KEY ([HomeworkStatusID]) REFERENCES [dbo].[HomeworkStatus]([ID]) ,
	TestStatusID int NULL,
	HomeworkDate datetime2 NULL
	

)
