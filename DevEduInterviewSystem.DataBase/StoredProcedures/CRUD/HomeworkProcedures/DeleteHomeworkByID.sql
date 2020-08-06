CREATE PROCEDURE [dbo].[DeleteHomeworkByID]
@ID int
AS
BEGIN
Delete from [dbo].[Homework] where (@ID = ID)
END
