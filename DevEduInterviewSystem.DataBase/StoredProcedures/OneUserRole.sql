CREATE PROCEDURE [dbo].[OneUserRoles] 
@UserID int
AS
SELECT  U.[FirstName], U.[LastName], U.[Login], R.[TypeOfRole] 
FROM dbo.[USER] AS U
JOIN dbo.[User_Role] AS UR ON U.[ID] = UR.[UserID]
JOIN dbo.[Role] AS R ON R.[ID] = UR.[RoleID]
WHERE U.[ID] = @UserID AND U.IsDeleted = 0