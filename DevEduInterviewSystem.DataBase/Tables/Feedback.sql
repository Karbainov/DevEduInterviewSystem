CREATE TABLE [dbo].[Feedback] (
	ID int Primary key Identity,
	StageChangedID int NULL, --FOREIGN KEY ([StageChangedID]) REFERENCES [StageChanged]([ID])
	UserID int NULL,--FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
	Message nvarchar(2500)  NULL,
	TimeFeedback datetime2 NULL,
 )