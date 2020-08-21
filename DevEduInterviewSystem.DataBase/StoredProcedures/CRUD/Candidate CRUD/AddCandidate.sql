CREATE Procedure [dbo].[AddCandidate]
  
  @StageID int null, 
  @StatusID int null,
  @CityID int null,
  @Phone NVARCHAR(12) null,
  @Email nvarchar(30) null,
  @FirstName nvarchar(30) null,
  @LastName nvarchar(30) null,
  @Birthday datetime2 null
  as
  begin
  insert into [dbo].[Candidate] 
  values (@StageID, @StatusID, @CityID, @Phone, @Email, @FirstName, @LastName, @Birthday)
  --SELECT SCOPE_IDENTITY()
  end
