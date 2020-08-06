Create Procedure dbo.[AddGroup]
@CourceID int,
@Name nvarchar(50),
@StartDate datetime2,
@EndDate datetime2
AS
INSERT INTO dbo.[Group]
VALUES (@CourceID, @Name, @StartDate, @EndDate)
