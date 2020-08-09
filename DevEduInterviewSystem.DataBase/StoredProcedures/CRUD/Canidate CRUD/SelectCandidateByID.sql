CREATE Procedure [dbo].[SelectCandidateByID]
  @ID int 
  as
  begin
  select * From [dbo].[Candidate] where (@ID = ID)
  end
