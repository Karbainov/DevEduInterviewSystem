Create Procedure [dbo].[AddInterviewStatus]
@Name nvarchar (30) NULL
AS
INSERT INTO [dbo].[InterviewStatus]
VALUES (@Name)
