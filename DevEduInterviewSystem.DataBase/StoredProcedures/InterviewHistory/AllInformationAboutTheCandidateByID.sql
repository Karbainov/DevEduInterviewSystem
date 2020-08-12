CREATE PROCEDURE [dbo].[AllInformationAboutTheCandidateByID]
@ID int
AS
	SELECT C.FirstName, C.LastName, C.Email, C.Phone, C.Birthday, S.[Name],St.[Name],Ct.[Name], F.[Message],Cu.[Name], G.[Name],
	CPI.MaritalStatus, CPI.Education, CPI.WorkPlace, CPI.ITExperience, CPI.Hobbies, CPI.InfoSourse, CPI.Expectations 
	FROM dbo.[Candidate]  AS C 	
	JOIN dbo.[Stage] AS S ON S.ID = C.StageID
	JOIN dbo.[Status] AS St ON St.ID = C.StatusID
	JOIN dbo.[City] AS Ct ON ct.ID = C.CityID
	JOIN dbo.[StageChanged] AS SC ON sc.CandidateID = C.ID
	JOIN dbo.[Feedback] AS F ON F.StageChangedID = SC.ID
	JOIN dbo.[CandidatePersonalInfo] AS CPI ON CPI.CandidateID = C.ID	
	JOIN dbo.[Group_Candidate] AS GC ON GC.CandidateID = C.ID
	JOIN dbo.[Group] AS G ON G.ID = GC.GroupID
	JOIN dbo.[Course] Cu ON Cu.ID = G.CourseID
	WHERE C.ID = @ID
	GROUP BY C.ID,C.StageID, c.StatusID, c.CityID, c.Phone, C.Email, C.FirstName, C.LastName, C.Birthday, S.[Name],St.[Name],Ct.[Name], F.[Message],Cu.[Name], G.[Name],
	CPI.MaritalStatus, CPI.Education, CPI.WorkPlace, CPI.ITExperience, CPI.Hobbies, CPI.InfoSourse, CPI.Expectations 