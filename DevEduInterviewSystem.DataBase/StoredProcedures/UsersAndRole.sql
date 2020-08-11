CREATE PROCEDURE [dbo].[UsersAndRole] AS

	SELECT U.Login, U.FirstName, U.LastName, R.TypeOfRole FROM User_Role AS UR
	INNER JOIN [User] AS U ON U.ID = UR.UserID
	INNER JOIN [Role] AS R ON R.ID = UR.RoleID

