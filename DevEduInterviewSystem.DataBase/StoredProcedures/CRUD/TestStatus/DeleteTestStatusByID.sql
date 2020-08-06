CREATE PROCEDURE [dbo].[DeleteTestStatusByID]
@ID int
AS
Delete from [dbo].[TestStatus] where (@ID = ID)
