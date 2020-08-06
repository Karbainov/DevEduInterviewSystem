CREATE TABLE [dbo].[Group_Candidate]
(
	[ID] int Primary Key Identity,
	[GroupID] int NULL,	--FOREIGN KEY ([GroupID]) REFERENCES [Group]([ID])
	[CandidateID] int NULL --FOREIGN KEY ([CandidateID]) REFERENCES [Candidate]([ID])
)
