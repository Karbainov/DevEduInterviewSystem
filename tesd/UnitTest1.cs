using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace tesd
{
    public class Tests
    {
        CandidateDTO candidate;
        CandidatePersonalInfoDTO candidatePersonalInfo;
        StageDTO stage;
        StatusDTO status;
        CityDTO city;
        FeedbackDTO feedback;
        UserDTO user;
        StageChangedDTO stageChanged;
        CourseDTO course;
        GroupDTO group;
        GroupCandidateDTO groupCandidate;

        CandidateCRUD cRUD = new CandidateCRUD();
        CandidatePersonalInfoCRUD candidatePersonalInfoCRUD = new CandidatePersonalInfoCRUD();
        StageCRUD stageCRUD = new StageCRUD();
        StatusCRUD statusCRUD = new StatusCRUD();
        CityCRUD cityCRUD = new CityCRUD();
        FeedbackCRUD feedbackCRUD = new FeedbackCRUD();
        UserCRUD userCRUD = new UserCRUD();
        StageChangedCRUD stageChangedCRUD = new StageChangedCRUD();
        CourseCRUD courseCRUD = new CourseCRUD();
        GroupCRUD groupCRUD = new GroupCRUD();
        GroupCandidateCRUD groupCandidateCRUD = new GroupCandidateCRUD();

        int candidateID;
        int stageID;
        int statusID;
        int cityID;
        int feedBackID;
        int userID;
        int stagechangedID;
        int candedatepersonalinfoID;
        int courseID;
        int groupID;
        int groupCandidateID;
        [OneTimeSetUp]
        public void Setup()
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;

            stage = new StageDTO(40, "interview");            
            stageID = stageCRUD.Add(stage);

            status = new StatusDTO(40,"Like");            
            statusID = statusCRUD.Add(status);

            city = new CityDTO(40, "Saint-Petersburg");            
            cityID = cityCRUD.Add(city);
            
            DateTime date = new DateTime(1995,5,3);
            
            candidate = new CandidateDTO(40, stageID, statusID, cityID, "123456789", "email", "vasa", "pupkin", date);            
            candidateID = cRUD.Add(candidate);

            stageChanged = new StageChangedDTO(1, stageID, candidateID, DateTime.Now);            
            stagechangedID = stageChangedCRUD.Add(stageChanged);

            user = new UserDTO(1,"qwer","1234","rewq","tarf");            
            userID = userCRUD.Add(user);

            feedback = new FeedbackDTO(2, stagechangedID, userID, "Норм парень, второй илон макс!", DateTime.Now);            
            feedBackID = feedbackCRUD.Add(feedback);

            candidatePersonalInfo = new CandidatePersonalInfoDTO(1, candidateID, false, "da", "macduck", "Da", "rubis cube", "like song", "123");
            candedatepersonalinfoID = candidatePersonalInfoCRUD.Add(candidatePersonalInfo);

            //course = new CourseDTO("backend");
            //courseID = courseCRUD.Add(course);

            //group = new GroupDTO(1, courseID, "back #1", DateTime.Now, DateTime.Now);
            //groupID = groupCRUD.Add(group);

            //groupCandidate = new GroupCandidateDTO(1, groupID, candidateID);
            //groupCandidateID = groupCandidateCRUD.Add(groupCandidate);

        }
        //[OneTimeTearDown]
        //public void TearDown()
        //{
        //    cRUD.DeleteByID(candidateID);

        //    feedbackCRUD.DeleteByID(feedBackID);
        //}

        [Test]
        public void Test1()
        {
            AllInformationAboutTheCandidateByIDProcedure candidateByIDProcedure = new AllInformationAboutTheCandidateByIDProcedure();
            AllInformationAboutTheCandidateByIDDTO allInfoCandidate = candidateByIDProcedure.AllInformationAboutTheCandidateByID(candidateID);
            Assert.AreEqual(candidateID, allInfoCandidate.ID);
            Assert.AreEqual(stage.Name, allInfoCandidate.TypeOfStage);
            Assert.AreEqual(status.Name, allInfoCandidate.TypeOfStatus);
            Assert.AreEqual(city.CityName, allInfoCandidate.CityName);
            //Assert.AreEqual(candidate.Phone, allInfoCandidate.Phone);
            Assert.AreEqual(candidate.Email, allInfoCandidate.Email);
            Assert.AreEqual(candidate.FirstName, allInfoCandidate.FirstName);
            Assert.AreEqual(candidate.LastName, allInfoCandidate.LastName);
            Assert.AreEqual(candidate.BirthDay, allInfoCandidate.Birthday);
            Assert.AreEqual(feedback.Message, allInfoCandidate.FeedBack);
            Assert.AreEqual(candidatePersonalInfo.WorkPlace, allInfoCandidate.WorkPlace);
            Assert.AreEqual(candidatePersonalInfo.MaritalStatus, allInfoCandidate.MaritalStatus);
            Assert.AreEqual(candidatePersonalInfo.ITExperience, allInfoCandidate.ITExperience);
            Assert.AreEqual(candidatePersonalInfo.InfoSourse, allInfoCandidate.InfoSourse);
            Assert.AreEqual(candidatePersonalInfo.Hobbies, allInfoCandidate.Hobbies);
            Assert.AreEqual(candidatePersonalInfo.Expectations, allInfoCandidate.Expectations);
            //Assert.AreEqual(group.Name, allInfoCandidate.GroupName);
            //Assert.AreEqual(course.Name, allInfoCandidate.CourseName);

        }
    }
}