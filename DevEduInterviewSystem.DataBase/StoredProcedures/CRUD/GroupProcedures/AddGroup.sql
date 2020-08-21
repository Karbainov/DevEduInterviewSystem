Create Procedure dbo.[AddGroup]
@CourseID int,
@Name nvarchar(50),
@StartDate datetime2,
@EndDate datetime2
AS
INSERT INTO dbo.[Group]
VALUES (@CourseID, @Name, @StartDate, @EndDate)
  SELECT SCOPE_IDENTITY()
