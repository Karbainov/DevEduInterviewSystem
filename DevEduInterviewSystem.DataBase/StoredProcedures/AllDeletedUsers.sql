CREATE PROCEDURE [dbo].[AllDeletedUsers] AS
SELECT U.[ID], U.[FirstName], U.[LastName], U.[Login], U.[Password], R.[TypeOfRole] 
FROM [dbo].[User] AS U
JOIN dbo.[User_Role] AS UR ON U.[ID] = UR.[UserID]
JOIN dbo.[Role] AS R ON R.[ID] = UR.[RoleID]
WHERE  U.IsDeleted = 1
