CREATE PROCEDURE [dbo].[AllInformationAboutTheCandidateByID]
@ID int
AS
	SELECT C.ID, C.FirstName, C.LastName, C.Email, C.Phone, C.Birthday, S.[Name] AS TypeOfStage,St.[Name] AS TypeOfStatus, Ct.[Name] AS CityName, F.[Message] AS FeedBack,
	Cu.[Name] AS CourseName, G.[Name] AS GroupName, CPI.MaritalStatus, CPI.Education, CPI.WorkPlace, CPI.ITExperience, CPI.Hobbies, CPI.InfoSourse, CPI.Expectations 
	FROM dbo.[Candidate]  AS C 	
	JOIN dbo.[Stage] AS S ON S.ID = C.StageID
	JOIN dbo.[Status] AS St ON St.ID = C.StatusID
	JOIN dbo.[City] AS Ct ON ct.ID = C.CityID
	LEFT JOIN dbo.[StageChanged] AS SC ON sc.CandidateID = C.ID
	LEFT JOIN dbo.[Feedback] AS F ON F.StageChangedID = SC.ID
	LEFT JOIN dbo.[CandidatePersonalInfo] AS CPI ON CPI.CandidateID = C.ID	
	LEFT JOIN dbo.[Group_Candidate] AS GC ON GC.CandidateID = C.ID
	LEFT JOIN dbo.[Group] AS G ON G.ID = GC.GroupID
	LEFT JOIN dbo.[Course] Cu ON Cu.ID = G.CourseID
	WHERE C.ID = @ID
