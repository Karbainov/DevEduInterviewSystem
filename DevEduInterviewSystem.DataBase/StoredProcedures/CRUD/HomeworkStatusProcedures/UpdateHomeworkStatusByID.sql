CREATE PROCEDURE [dbo].[UpdateHomeworkStatusByID]
@ID int,
@Name nvarchar(30)
as
begin
Update [dbo].[HomeworkStatus] 

set Name = @Name 
where (ID = @ID)
end