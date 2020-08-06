Create Procedure [dbo].[SelectInterviewByID]
@ID int
AS
Select * From [dbo].[Interview] where (@ID = ID)
