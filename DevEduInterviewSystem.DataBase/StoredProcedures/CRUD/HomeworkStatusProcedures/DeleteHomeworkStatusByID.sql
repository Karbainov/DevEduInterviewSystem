CREATE PROCEDURE [dbo].[DeleteHomeworkStatusByID]
@ID int 
as
begin
DELETE from  [dbo].[HomeworkStatus] where (@ID = ID)
end
