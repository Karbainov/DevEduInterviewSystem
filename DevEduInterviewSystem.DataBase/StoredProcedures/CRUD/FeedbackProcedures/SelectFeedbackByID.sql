CREATE PROCEDURE [dbo].[SelectFeedbackByID]
@ID int 
as
begin
select * From [dbo].[Feedback] where (@ID = ID)

end