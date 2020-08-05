

Create Procedure [dbo].[UpdateStageByID]
@ID int,
@Name nvarchar(30)
as

Update [dbo].[Stage]
Set Name = @Name
where (ID = @ID)