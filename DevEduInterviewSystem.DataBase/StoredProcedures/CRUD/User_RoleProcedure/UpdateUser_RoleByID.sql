CREATE PROCEDURE [dbo].[UpdateUser_RoleByID]
@ID int,
@UserID int,
@RoleID int
AS
BEGIN
UPDATE [dbo].[User_Role]
SET UserID = @UserID, 
RoleID = @RoleID  
where (@ID = ID)
end