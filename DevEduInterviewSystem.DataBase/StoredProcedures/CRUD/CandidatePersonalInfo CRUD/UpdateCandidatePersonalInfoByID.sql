Create Procedure dbo.[UpdateCandidatePersonalInfoByID]
@ID int,
@CandidateID int,
@MaritalStatus bit,
@Education nvarchar(50),
@WorkPlace nvarchar(50),
@ITExperience nvarchar(50),
@Hobbies nvarchar(50),
@InfoSourse nvarchar(50),
@Expectations nvarchar(50)
AS
BEGIN
UPDATE dbo.[CandidatePersonalInfo]
SET CandidateID = @CandidateID,
MaritalStatus = @MaritalStatus,
Education = @Education,
WorkPlace = @WorkPlace,
ITExperience = @ITExperience,
Hobbies = @Hobbies,
InfoSourse = @InfoSourse,
Expectations = @Expectations
where (@ID = ID)
end
