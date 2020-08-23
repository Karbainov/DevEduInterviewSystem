CREATE PROCEDURE [dbo].[DeleteCityByID]
	@ID int 
AS
BEGIN
UPDATE [dbo].[City]
SET IsDeleted = 1
WHERE (@ID = ID AND IsDeleted = 0)
END
