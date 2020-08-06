Create Procedure [dbo].[SelectInterviewStatusByID]
@ID int
AS
Select * From [dbo].[InterviewStatus] where (@ID = ID)
