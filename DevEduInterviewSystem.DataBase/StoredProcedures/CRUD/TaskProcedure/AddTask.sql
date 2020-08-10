﻿CREATE PROCEDURE [dbo].[AddTask]
@UserID int,
@CandidateID int,
@Message nvarchar (2500),
@IsCompleted nvarchar (50)
AS
INSERT INTO [dbo].[Task]
VALUES (@UserID, @CandidateID, @Message, @IsCompleted)
