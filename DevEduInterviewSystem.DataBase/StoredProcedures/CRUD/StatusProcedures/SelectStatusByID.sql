CREATE PROCEDURE [dbo].[SelectStatusByID]
@ID int 
as
begin
select * From [dbo].[Status] where (@ID = ID)
end

