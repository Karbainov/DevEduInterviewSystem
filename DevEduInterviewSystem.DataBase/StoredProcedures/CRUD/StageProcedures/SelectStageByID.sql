

Create Procedure [dbo].[SelectStageByID]
@ID int
as
select * From [dbo].[Stage] where (@ID = ID)
