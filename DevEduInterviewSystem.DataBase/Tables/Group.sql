CREATE TABLE [dbo].[Group]
(
	[ID] int Primary Key Identity,
	[CourseID] int NULL FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course]([ID]),
	[Name] nvarchar(50),
	[StartDate] datetime2,
	[EndDate] datetime2
)
