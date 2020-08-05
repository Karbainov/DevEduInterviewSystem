
Create Procedure dbo.[SelectUser_InterviewByID]
@ID int 
AS
Select  * From [dbo].[User_Interview] where (@ID = ID)
