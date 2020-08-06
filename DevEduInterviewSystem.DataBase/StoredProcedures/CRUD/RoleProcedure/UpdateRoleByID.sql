CREATE PROCEDURE [dbo].[UpdateRoleByID]
@ID int,
@TypeOfRole nvarchar(30)
AS
BEGIN
UPDATE [dbo].[Role]
SET TypeOfRole = @TypeOfRole   
where (@ID = ID)
end