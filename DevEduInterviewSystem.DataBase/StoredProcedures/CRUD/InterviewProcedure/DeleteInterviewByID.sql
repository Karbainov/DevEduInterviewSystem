Create Procedure [dbo].[DeleteInterviewByID]
@ID int
AS
Delete from [dbo].[Interview] where (@ID = ID)
