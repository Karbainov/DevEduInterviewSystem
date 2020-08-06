CREATE TABLE dbo.[Candidate] (
	[ID] int Primary key Identity,
	[StageID] int FOREIGN KEY ([StageID]) REFERENCES [Stage]([ID]) NULL,
	[StatusID] int FOREIGN KEY ([StatusID]) REFERENCES [Status]([ID]) NULL,
	[CityID] int FOREIGN KEY ([CityID]) REFERENCES [City]([ID]) NULL,
	[Phone] int NULL,
	[Email] nvarchar(30) NULL,
	[FirstName] nvarchar(30) NULL,
	[LastName] nvarchar(30) NULL,
	[Birthday] datetime2 NULL
)
