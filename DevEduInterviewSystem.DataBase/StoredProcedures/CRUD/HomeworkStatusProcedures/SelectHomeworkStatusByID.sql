CREATE PROCEDURE [dbo].[SelectHomeworkStatusByID]
@ID int 
as
begin
select * From [dbo].[HomeworkStatus] where (@ID = ID)
end
