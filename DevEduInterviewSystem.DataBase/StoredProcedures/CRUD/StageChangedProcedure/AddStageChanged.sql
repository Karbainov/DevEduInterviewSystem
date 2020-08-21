CREATE PROCEDURE [dbo].[AddStageChanged]
@CandidateID int null,
@StageID int null,
@ChangedDate datetime2 null
AS
INSERT INTO [dbo].[StageChanged]
VALUES (@CandidateID, @StageID, @ChangedDate)
--SELECT SCOPE_IDENTITY()