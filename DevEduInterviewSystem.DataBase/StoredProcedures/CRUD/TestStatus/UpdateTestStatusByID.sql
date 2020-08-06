CREATE PROCEDURE [dbo].[UpdateTestStatusByID]
@ID int,
@Name nvarchar(50)
AS
BEGIN
UPDATE [dbo].[TestStatus]
SET Name = @Name
where (@ID = ID)
end
