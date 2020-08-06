Create Procedure [dbo].[UpdateInterviewStatusByID]
@ID int,
@Name nvarchar (30)
AS
begin
UPDATE [dbo].[InterviewStatus]
SET Name = @Name
where (@ID = ID)
end
