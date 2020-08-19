CREATE PROCEDURE [dbo].[AllDeletedUsers] AS
SELECT * FROM [dbo].[User] AS U
WHERE  U.IsDeleted = 1
