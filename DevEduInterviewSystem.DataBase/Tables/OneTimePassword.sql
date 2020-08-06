CREATE TABLE [dbo].[OneTimePassword]
(
	ID int Primary key Identity,
	CandidateID int NULL FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidate]([ID]),
	OneTimePasswordDate datetime2 NULL,
	OneTimePassword int NULL
 )

