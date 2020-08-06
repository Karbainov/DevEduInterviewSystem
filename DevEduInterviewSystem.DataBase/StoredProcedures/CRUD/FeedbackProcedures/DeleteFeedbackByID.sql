CREATE PROCEDURE  [dbo].[DeleteFeedbackByID]
@ID int 
as
begin
DELETE from  [dbo].[Feedback] where (@ID = ID)

end