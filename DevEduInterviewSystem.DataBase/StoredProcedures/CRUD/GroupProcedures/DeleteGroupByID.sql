Create Procedure dbo.[DeleteGroupByID]
@ID int
AS
BEGIN
UPDATE [dbo].[Group]
SET IsDeleted = 1
WHERE (@ID = ID AND IsDeleted = 0)
END