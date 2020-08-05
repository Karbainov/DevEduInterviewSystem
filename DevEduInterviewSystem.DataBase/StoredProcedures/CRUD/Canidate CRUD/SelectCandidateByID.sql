CREATE Procedure SelectCandidateByID
  @ID int 
  as
  begin
  select * From dbo.[Candidate] where (@ID = ID)
  end
