CREATE Procedure UpdateCandidateByID
  @ID int,
  @StageID int, 
  @StatusID int,
  @CityID int,
  @Phone int,
  @Email nvarchar(30),
  @FirstName nvarchar(30),
  @LastName nvarchar(30),
  @Birthday datetime2
  as
  begin
  Update dbo.[Candidate] 
  set StageID = @StageID,
  StatusID = @StatusID,
  CityID = @CityID,
  Phone = @Phone,
  Email = @Email,
  FirstName = @FirstName,
  LastName = @LastName,
  Birthday = @Birthday
  
  where (ID = @ID)
  end