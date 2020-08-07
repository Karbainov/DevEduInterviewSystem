Create Procedure [dbo].[UpdateCourseByID]
	@ID int,
	@Name nvarchar (20)
AS
BEGIN
UPDATE [dbo].[Course]
SET Name = @Name
where (@ID = ID)
end