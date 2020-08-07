CREATE PROCEDURE [dbo].[DeleteCityByID]
	@ID int 
AS
Delete from [dbo].[City] 
where (@ID = ID)
