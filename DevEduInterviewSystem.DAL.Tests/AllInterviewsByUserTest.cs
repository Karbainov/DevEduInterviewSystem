using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
using DevEduInterviewSystem.DAL.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.Tests
{
    [TestFixture]
    public class AllInterviewsByUserTest
    {
        //private AllInterviewsByUserQuery _allInterviewsQuery;
        private List<int> _mockID = new List<int>();
        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            //ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            Connection = ConnectionSingleTone.GetInstance().Connection;

            UserCRUD userCRUD = new UserCRUD();
            UserDTOMock userDTOMock = new UserDTOMock();
            Connection.Close();
            foreach (UserDTO dto in userDTOMock)
            {
                _mockID.Add(userCRUD.Add(dto));
                Connection.Close();
            }


            CityCRUD cityCRUD = new CityCRUD();
            CityDTOMock cityDTOMock = new CityDTOMock();
            Connection.Close();
            foreach (CityDTO dto in cityDTOMock)
            {
                cityCRUD.Add(dto);
                Connection.Close();
            }

            StatusCRUD statusCRUD = new StatusCRUD();
            StatusDTOMock statusDTOMock = new StatusDTOMock();
            foreach (StatusDTO dto in statusDTOMock)
            {
                statusCRUD.Add(dto);
                Connection.Close();
            }

            StageCRUD stageCRUD = new StageCRUD();
            StageDTOMock stageDTOMock = new StageDTOMock();
            foreach (StageDTO dto in stageDTOMock)
            {
                stageCRUD.Add(dto);
                Connection.Close();
            }

            InterviewStatusCRUD interviewStatusCRUD = new InterviewStatusCRUD();
            InterviewStatusDTOMock interviewStatusDTOMock = new InterviewStatusDTOMock();
            foreach (InterviewStatusDTO dto in interviewStatusDTOMock)
            {
                interviewStatusCRUD.Add(dto);
                Connection.Close();
            }

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                candidateCRUD.Add(dto);
                Connection.Close();
            }

            InterviewCRUD interviewCRUD = new InterviewCRUD();
            InterviewDTOMock interviewDTOMock = new InterviewDTOMock();
            foreach (InterviewDTO dto in interviewDTOMock)
            {
                interviewCRUD.Add(dto);
                Connection.Close();
            }

            UserInterviewCRUD userInterviewCRUD = new UserInterviewCRUD();
            UserInterviewDTOMock userInterviewDTOMock = new UserInterviewDTOMock();
            foreach (UserInterviewDTO dto in userInterviewDTOMock)
            {
                userInterviewCRUD.Add(dto);
                Connection.Close();
            }
        } 

        [Test, TestCaseSource(typeof(AllInterviewsByUserQueryDataSource))]
        public void SelectAllByUserTest(int idnumber, AllInterviewsByUserDTO expected)
        {
            AllInterviewsByUserQuery _allInterviewsQuery = new AllInterviewsByUserQuery();
            List<AllInterviewsByUserDTO> actual = _allInterviewsQuery.SelectAllByUser(idnumber);
            Connection.Close();
 
            AllInterviewsByUserDTO actualDTO = actual[1];
            Assert.AreEqual(expected.UserFirstName, actualDTO.UserFirstName);
        }

        [TearDown]
        public void TearDown()
        {
            //Удаление добавленных элементов

        }

        public class AllInterviewsByUserQueryDataSource : IEnumerable
        {
            

            AllInterviewsByUserDTO interview = new AllInterviewsByUserDTO()
            {
                UserID = 0,
                UserFirstName = "Sergey",
                UserLastName = "Timofeev",
                IDCandidate = 30,
                CandidateFirstName = "Vasya",
                CandidateLastName = "Pupkin",
                CandidatePhone = "911",
                DateTimeInterview = new DateTime(2020, 08, 12, 21, 42, 24),
                Attempt = 1,
                InterviewStatus = "success"
            };


         AllInterviewsByUserDTO candidate2 = new AllInterviewsByUserDTO(){CandidateFirstName = "Polina"};



            AllInterviewsByUserDTO candidate3 = new AllInterviewsByUserDTO()
            {
                CandidateFirstName = "Svetlana"
            };



            public IEnumerator GetEnumerator()
            {
                //list1.Add(candidate);
                //yield return list1;
                //list2.Add(candidate2);                
                //yield return list2;
                //list3.Add(candidate3);
                //yield return list3;

                yield return new object[] { 65, interview };
                yield return new object[] { 66, candidate2 };
                yield return new object[] { 67, candidate3 };
            }
        }
    }
}