CREATE Procedure AddCandidate
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
  insert into dbo.[Candidate] 
  values (@StageID, @StatusID, @CityID, @Phone, @Email, @FirstName, @LastName, @Birthday)
  end
