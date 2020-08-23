Create Procedure dbo.[UpdateGroupByID]
@ID int,
@CourseID int,
@Name nvarchar(50),
@StartDate datetime2,
@EndDate datetime2
AS
UPDATE dbo.[Group]
SET 
Name = @Name,
StartDate = @StartDate,
EndDate = @EndDate
where (@ID = ID)