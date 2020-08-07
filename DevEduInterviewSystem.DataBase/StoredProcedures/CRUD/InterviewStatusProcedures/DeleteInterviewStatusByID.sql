Create Procedure [dbo].[DeleteInterviewStatusByID]
@ID int
AS
Delete from [dbo].[InterviewStatus] where (@ID = ID)
