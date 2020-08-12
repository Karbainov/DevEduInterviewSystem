Create Procedure [dbo].[DeleteCourseByID] 
	@ID int
AS
Delete from [dbo].[Course] where (@ID = ID)