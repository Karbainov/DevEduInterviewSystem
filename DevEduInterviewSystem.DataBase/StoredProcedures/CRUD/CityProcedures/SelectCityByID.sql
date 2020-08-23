CREATE PROCEDURE [dbo].[SelectCityByID]
	@ID int 
AS
Select  * From [dbo].[City] 
where (@ID = ID) AND (IsDeleted=0)