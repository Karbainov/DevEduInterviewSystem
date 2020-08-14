Create Procedure [dbo].[AddCourse] 
	@Name nvarchar(30) 
AS 
INSERT INTO [dbo].[Course] 
VALUES (@Name)
  SELECT SCOPE_IDENTITY()
