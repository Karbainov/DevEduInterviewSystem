CREATE PROCEDURE [dbo].[DeleteStatusByID]
@ID int 
as
begin
DELETE from  [dbo].[Status] where (@ID = ID)
end
