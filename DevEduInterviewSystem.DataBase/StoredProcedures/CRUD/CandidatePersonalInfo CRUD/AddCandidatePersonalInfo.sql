Create Procedure dbo.[AddCandidatePersonalInfo]
@CandidateID int,
@MaritalStatus bit,
@Education nvarchar(50),
@WorkPlace nvarchar(50),
@ITExperience nvarchar(50),
@Hobbies nvarchar(50),
@InfoSourse nvarchar(50),
@Expectations nvarchar(50)
AS
INSERT INTO dbo.[CandidatePersonalInfo]
VALUES (@CandidateID, @MaritalStatus, @Education, @WorkPlace, @ITExperience, @Hobbies, @InfoSourse, @Expectations)