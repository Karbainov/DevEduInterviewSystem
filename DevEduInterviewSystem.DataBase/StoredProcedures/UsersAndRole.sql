CREATE PROCEDURE [dbo].[UsersAndRole] AS


	SELECT  U.FirstName, U.LastName, U.[Login], U.[Password] , R.TypeOfRole FROM dbo.[USER] AS U
	INNER JOIN dbo.[User_Role] AS UR ON U.ID = UR.UserID
	INNER JOIN dbo.[Role] AS R ON R.ID = UR.RoleID
	WHERE U.IsDeleted = 0