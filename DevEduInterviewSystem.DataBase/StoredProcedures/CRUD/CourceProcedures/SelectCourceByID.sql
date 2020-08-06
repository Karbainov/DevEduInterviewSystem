Create Procedure [dbo].[SelectCourseByID]
	@ID int 
AS
Select  * From [dbo].[Course] where (@ID = ID)