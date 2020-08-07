CREATE PROCEDURE [dbo].[SelectTestStatusByID]@ID int
AS
Select * From [dbo].[TestStatus] where (@ID = ID)
