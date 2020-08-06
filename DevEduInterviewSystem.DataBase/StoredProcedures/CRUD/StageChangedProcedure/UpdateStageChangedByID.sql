CREATE PROCEDURE [dbo].[UpdateStageChangedByID]
@ID int,
@CandidateID bigint,
@StageID int,
@ChangedDate datetime2
AS
BEGIN
UPDATE [dbo].[StageChanged]
SET  CandidateID = @CandidateID,
StageID = @StageID ,
ChangedDate = @ChangedDate
where (@ID = ID)
end
