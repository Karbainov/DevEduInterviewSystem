
Create Procedure [dbo].[AddUser_Interview]
@InterviewID int,
@UserID int

AS
INSERT INTO [dbo].[User_Interview]
VALUES (@InterviewID, @UserID)
