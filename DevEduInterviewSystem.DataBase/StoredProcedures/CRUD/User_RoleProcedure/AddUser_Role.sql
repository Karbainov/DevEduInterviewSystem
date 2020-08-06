CREATE PROCEDURE [dbo].[AddUser_Role]
@UserID int,
@RoleID int
AS
INSERT INTO [dbo].[User_Role]
VALUES (@UserID, @RoleID)
