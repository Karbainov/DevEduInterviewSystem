CREATE PROCEDURE [dbo].[SelectHomeworkByID]
	@ID int 
AS
BEGIN
select * From [dbo].[Homework] where (@ID = ID)

END
