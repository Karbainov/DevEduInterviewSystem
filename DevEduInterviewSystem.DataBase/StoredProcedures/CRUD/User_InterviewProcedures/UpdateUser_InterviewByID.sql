Create Procedure [dbo].[UpdateUser_InterviewByID] 
@ID int,
@InterviewID int,
@UserID int
AS
BEGIN
UPDATE [dbo].[User_Interview]
SET InterviewID = @InterviewID,
UserID = @UserID
 
where (@ID = ID)
end