CREATE TABLE [dbo].[City]
(
	[ID] int NOT NULL PRIMARY KEY IDENTITY, 
	[Name] nvarchar(30) NULL,
	[IsDeleted] BIT default 0
)