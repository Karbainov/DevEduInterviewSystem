Create Procedure dbo.[UpdateGroupByID]
@ID int,
@CourseID int,
@Name nvarchar(50),
@StartDate datetime2,
@EndDate datetime2
AS
BEGIN
UPDATE dbo.[Group]
SET 
Name = @Name,
StartDate = @StartDate,
EndDate = @EndDate
WHERE (@ID = ID) AND (IsDeleted = 0)
END