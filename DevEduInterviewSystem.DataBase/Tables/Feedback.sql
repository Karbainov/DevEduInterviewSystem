CREATE TABLE [dbo].[Feedback] (
	ID int Primary key Identity,
	StageChangedID int NULL FOREIGN KEY ([StageChangedID]) REFERENCES [dbo].[StageChanged]([ID]),
	UserID int NULL FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([ID]),
	Message nvarchar(2500)  NULL,
	TimeFeedback datetime2 NULL,
 )