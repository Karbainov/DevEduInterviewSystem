CREATE PROCEDURE AddHomeworkStatus
@Name nvarchar(30)
as
begin
INSERT INTO dbo.[HomeworkStatus]
VALUES (@Name )
end