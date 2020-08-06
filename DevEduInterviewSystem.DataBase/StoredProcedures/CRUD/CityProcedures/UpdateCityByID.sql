Create Procedure [dbo].[UpdateCityByID]
	@ID int,
	@Name nvarchar (20)
AS
BEGIN
UPDATE [dbo].[City]
SET Name = @Name
where (@ID = ID)
end