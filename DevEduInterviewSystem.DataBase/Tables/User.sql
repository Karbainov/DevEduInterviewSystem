﻿CREATE TABLE [dbo].[User]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Login] NVARCHAR(50) NULL,
	[Password] NVARCHAR(50) NULL,
	[FirstName] NVARCHAR(50) NULL,
	[LastName] NVARCHAR(50) NULL,
	[IsDeleted] BIT default 0
)
