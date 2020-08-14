CREATE TABLE [dbo].[CandidatePersonalInfo] (
	[ID] int Primary key Identity,
	[CandidateID] int FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID]) NULL,
	[MaritalStatus] bit NULL,
	[Education] nvarchar(50) NULL,
	[WorkPlace] nvarchar(50) NULL,
	[ITExperience] nvarchar(50) NULL,
	[Hobbies] nvarchar(50) NULL,
	[InfoSourse] nvarchar(50) NULL,
	[Expectations] nvarchar(50) NULL
)
