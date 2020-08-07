Create Procedure [dbo].[AddTestStatus]
@Name nvarchar(50)
AS
INSERT INTO [dbo].[TestStatus]
VALUES (@Name)
