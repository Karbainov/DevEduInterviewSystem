Create Procedure dbo.[AddGroup]
@CourceID int,
@Name nvarchar(50),
@StartDate nvarchar(20),
@EndDate nvarchar(20)
AS
INSERT INTO dbo.[Group]
VALUES (@CourceID, @Name, @StartDate, @EndDate)
