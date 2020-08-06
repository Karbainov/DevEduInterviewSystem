CREATE PROCEDURE [dbo].[UpdateStatusByID]
@ID int,
@Name nvarchar(30)
as
begin
Update [dbo].[Status] 

set Name = @Name 
where (ID = @ID)
end
