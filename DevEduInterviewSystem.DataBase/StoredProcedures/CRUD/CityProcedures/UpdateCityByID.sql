Create Procedure UpdateCityByID 
	@ID int,
	@Name nvarchar (20)
AS
BEGIN
UPDATE City
SET Name = @Name
where (@ID = ID)
end