CREATE PROCEDURE [dbo].[AddStageChanged]
@CandidateID bigint,
@StageID int,
@ChangedDate datetime2
AS
INSERT INTO [dbo].[StageChanged]
VALUES (@CandidateID, @StageID, @ChangedDate)
