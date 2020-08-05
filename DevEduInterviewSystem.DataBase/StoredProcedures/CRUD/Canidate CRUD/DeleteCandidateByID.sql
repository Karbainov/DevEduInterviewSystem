CREATE Procedure DeleteCandidateByID
  @ID int 
  as
  begin
  DELETE from dbo.[Candidate] where (@ID = ID)
  end
