﻿CREATE TABLE dbo.[Candidate] (
	[ID] int Primary key Identity,
	[StageID] int FOREIGN KEY ([StageID]) REFERENCES dbo.[Stage]([ID]) NULL,
	[StatusID] int FOREIGN KEY ([StatusID]) REFERENCES dbo.[Status]([ID]) NULL,
	[CityID] INT FOREIGN KEY ([CityID]) REFERENCES dbo.[City]([ID]) NULL,
	[Phone] nvarchar(30) NULL,
	[Email] nvarchar(30) NULL,
	[FirstName] nvarchar(30) NULL,
	[LastName] nvarchar(30) NULL,
	[Birthday] datetime2 NULL
)
