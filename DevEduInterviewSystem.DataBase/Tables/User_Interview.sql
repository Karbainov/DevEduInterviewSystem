Create table [dbo].[User_Interview]
(
ID int primary key identity,
InterviewID int FOREIGN KEY ([InterviewID]) REFERENCES [dbo].[Interview]([ID]) NULL,
UserID int FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([ID]) NULL
)
