﻿Create table [dbo].[User_Interview]
(
ID int primary key identity,
InterviewID int NULL  FOREIGN KEY ([InterviewID]) REFERENCES [dbo].[Interview]([ID]),
UserID int NULL FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
)
