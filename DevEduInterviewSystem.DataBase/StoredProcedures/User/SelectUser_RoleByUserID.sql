CREATE PROCEDURE [dbo].[SelectUser_RoleByUserID] 
@ID int  
AS 
Select * From [dbo].[User_Role] where (@ID = UserID) 

--@ID int
--AS
--SELECT U.[ID], R.[TypeOfRole] 
--FROM dbo.[USER] AS U
--INNER JOIN dbo.[User_Role] AS UR ON U.[ID] = UR.[UserID]
--INNER JOIN dbo.[Role] AS R ON R.[ID] = UR.[RoleID]
--WHERE (@ID = UserID) AND (U.IsDeleted = 0)
