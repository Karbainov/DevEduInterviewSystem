Create Procedure [dbo].[AddInterviewStatus]
@Name nvarchar (30)
AS
INSERT INTO [dbo].[InterviewStatus]
VALUES (@Name)
