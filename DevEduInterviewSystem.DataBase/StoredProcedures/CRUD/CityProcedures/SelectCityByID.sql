CREATE PROCEDURE [dbo].[SelectCityByID]
	@ID int 
AS
Select  * From [dbo].[City] 
where (@ID = ID)