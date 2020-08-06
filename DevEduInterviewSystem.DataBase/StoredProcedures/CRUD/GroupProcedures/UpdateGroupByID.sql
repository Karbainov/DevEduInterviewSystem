Create Procedure dbo.[UpdateGroupByID]
@ID int,
@CourceID int,
@Name nvarchar(50),
@StartDate nvarchar(20),
@EndDate nvarchar(20)
AS
UPDATE dbo.[Group]
SET 
Name = @Name,
StartDate = @StartDate,
EndDate = @EndDate
where (@ID = ID)