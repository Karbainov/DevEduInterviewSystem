CREATE PROCEDURE [dbo].[DeleteStageChangedByID]
@ID int 
AS
Delete from [dbo].[StageChanged] where (@ID = ID)
