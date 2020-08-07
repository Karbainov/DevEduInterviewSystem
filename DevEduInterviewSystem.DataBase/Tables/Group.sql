CREATE TABLE [dbo].[Group]
(
	[ID] int Primary Key Identity,
	[CourceID] int NULL, --FOREIGN KEY ([CourseID]) REFERENCES [Course]([ID])
	[Name] nvarchar(50),
	[StartDate] datetime2,
	[EndDate] datetime2
)
