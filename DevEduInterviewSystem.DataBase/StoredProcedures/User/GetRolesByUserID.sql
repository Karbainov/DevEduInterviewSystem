CREATE PROCEDURE [dbo].[GetRolesByUserID]
@ID int  
AS 
SELECT R.[TypeOfRole] 
FROM dbo.[ROLE] AS R
INNER JOIN dbo.[User_Role] AS UR ON UR.[RoleID] = UR.[UserID]
WHERE (@ID = UR.[UserID])
