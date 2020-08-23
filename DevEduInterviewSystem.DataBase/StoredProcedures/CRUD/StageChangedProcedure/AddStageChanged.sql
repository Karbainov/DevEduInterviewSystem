CREATE PROCEDURE [dbo].[AddStageChanged]
@CandidateID int,
@StageID int,
@ChangedDate datetime2
AS
INSERT INTO [dbo].[StageChanged]
VALUES (@CandidateID, @StageID, @ChangedDate)
--SELECT SCOPE_IDENTITY()