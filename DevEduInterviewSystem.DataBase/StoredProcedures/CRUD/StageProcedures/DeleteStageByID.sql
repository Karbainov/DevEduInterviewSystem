

Create Procedure [dbo].[DeleteStageByID]
@ID int
as
DELETE From [dbo].[Stage] where (@ID = ID)
