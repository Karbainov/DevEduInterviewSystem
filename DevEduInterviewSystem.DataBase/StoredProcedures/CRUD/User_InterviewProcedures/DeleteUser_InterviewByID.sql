
Create Procedure dbo.[DeleteUser_InterviewByID]
@ID int 
AS
Delete from [dbo].[User_Interview] where (@ID = ID)
