using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
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
        private List<int> _mockUserID;
        private List<int> _mockInterviewID;
        private List<int> _mockCandidateID;
        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {            
            Connection = ConnectionSingleTone.GetInstance().Connection;
            _mockUserID = new List<int>();
            _mockInterviewID = new List<int>();
            _mockCandidateID = new List<int>();

            UserCRUD userCRUD = new UserCRUD();
            UserDTOMock userDTOMock = new UserDTOMock();
            Connection.Close();
            foreach (UserDTO dto in userDTOMock)
            {                
                _mockUserID.Add(userCRUD.Add(dto));
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
                _mockCandidateID.Add(candidateCRUD.Add(dto));
                Connection.Close();
            }

            InterviewCRUD interviewCRUD = new InterviewCRUD();
            InterviewDTOMock interviewDTOMock = new InterviewDTOMock();
            int count = 0;
            foreach (InterviewDTO dto in interviewDTOMock)
            {
                dto.CandidateID = _mockCandidateID[count];
                _mockInterviewID.Add(interviewCRUD.Add(dto));
                Connection.Close();
                count++;
            }

            UserInterviewCRUD userInterviewCRUD = new UserInterviewCRUD();
            for (int i = 0; i < _mockUserID.Count; i++)
            {
                UserInterviewDTO userInterview = new UserInterviewDTO(1, _mockInterviewID[i], _mockUserID[i]);
                UserInterviewDTO userInterview2 = new UserInterviewDTO(2, _mockInterviewID[_mockUserID.Count - i - 1], _mockUserID[i]);
                userInterviewCRUD.Add(userInterview);
                Connection.Close();
                userInterviewCRUD.Add(userInterview2);
                Connection.Close();
            }
        } 

        [Test, TestCaseSource(typeof(AllInterviewsByUserQueryDataSource))]
        public void SelectAllByUserTest(int idnumber, List<AllInterviewsByUserDTO> expected)
        {
            AllInterviewsByUserQuery _allInterviewsQuery = new AllInterviewsByUserQuery();
            List<AllInterviewsByUserDTO> actual = _allInterviewsQuery.SelectAllByUser(_mockUserID[idnumber]);

            Connection.Close();

            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {
            //�������� ����������� ���������

        }

        public class AllInterviewsByUserQueryDataSource : IEnumerable
        {
            List<AllInterviewsByUserDTO> firstTest = new List<AllInterviewsByUserDTO>();

            AllInterviewsByUserDTO interviewSergey1 = new AllInterviewsByUserDTO()
            {
                UserFirstName = "Sergey",
                UserLastName = "Timofeev",
                CandidateFirstName = "Vasya",
                CandidateLastName = "Pupkin",
                CandidatePhone = "911",
                DateTimeInterview = new DateTime(2020, 07, 20, 18, 30, 00),
                Attempt = 1,
                InterviewStatus = "success"
            };            

            AllInterviewsByUserDTO interviewSergey2 = new AllInterviewsByUserDTO()
            {
                UserFirstName = "Sergey",
                UserLastName = "Timofeev",
                CandidateFirstName = "Elena",
                CandidateLastName = "Kac",
                CandidatePhone = "8",
                DateTimeInterview = new DateTime(2020, 09, 12, 15, 00, 00),
                Attempt = 1,
                InterviewStatus = "fail"
            };

            List<AllInterviewsByUserDTO> secondTest = new List<AllInterviewsByUserDTO>();

            AllInterviewsByUserDTO interviewPolina1 = new AllInterviewsByUserDTO()
            {
                UserFirstName = "Polina",
                UserLastName = "Matveevna",
                CandidateFirstName = "Ivan",
                CandidateLastName = "Sidorov",
                CandidatePhone = "821",
                DateTimeInterview = new DateTime(2020, 8, 20, 10, 30, 00),
                Attempt = 2,
                InterviewStatus = "fail"
            };

            AllInterviewsByUserDTO interviewPolina2 = new AllInterviewsByUserDTO()
            {
                UserFirstName = "Polina",
                UserLastName = "Matveevna",
                CandidateFirstName = "Yana",
                CandidateLastName = "Smirnova",
                CandidatePhone = "8921",
                DateTimeInterview = new DateTime(2020, 9, 20, 12, 00, 00),
                Attempt = 1,
                InterviewStatus = "canceled"
            };

            List<AllInterviewsByUserDTO> thirdTest = new List<AllInterviewsByUserDTO>();

            AllInterviewsByUserDTO interviewSvetlana1 = new AllInterviewsByUserDTO()
            {
                UserFirstName = "Svetlana",
                UserLastName = "Fokina",
                CandidateFirstName = "Yana",
                CandidateLastName = "Smirnova",
                CandidatePhone = "8921",
                DateTimeInterview = new DateTime(2020, 09, 20, 12, 00, 00),
                Attempt = 1,
                InterviewStatus = "canceled"
            };

            AllInterviewsByUserDTO interviewSvetlana2 = new AllInterviewsByUserDTO()
            {
                UserFirstName = "Svetlana",
                UserLastName = "Fokina",
                CandidateFirstName = "Ivan",
                CandidateLastName = "Sidorov",
                CandidatePhone = "821",
                DateTimeInterview = new DateTime(2020, 08, 20, 10, 30, 00),
                Attempt = 2,
                InterviewStatus = "fail"
            };


            public IEnumerator GetEnumerator()
            {
                firstTest.Add(interviewSergey1);
                firstTest.Add(interviewSergey2);
                secondTest.Add(interviewPolina1);
                secondTest.Add(interviewPolina2);
                thirdTest.Add(interviewSvetlana1);
                thirdTest.Add(interviewSvetlana2);

                yield return new object[] { 0, firstTest };
                yield return new object[] { 1, secondTest };
                yield return new object[] { 2, thirdTest };
            }
        }
    }
}