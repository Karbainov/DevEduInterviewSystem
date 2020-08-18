﻿using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
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
    public class AllCandidateOfAllCoursesTest
    {
        private List<int> _mockCourseID;
        private List<int> _mockCandidateID;

        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            _mockCourseID = new List<int>();
            _mockCandidateID = new List<int>();

            CityCRUD cityCRUD = new CityCRUD();
            CityDTOMock cityDTOMock = new CityDTOMock();
            Connection.Close();
            foreach (CityDTO dto in cityDTOMock)
            {
                cityCRUD.Add(dto);
            }

            StatusCRUD statusCRUD = new StatusCRUD();
            StatusDTOMock statusDTOMock = new StatusDTOMock();
            foreach (StatusDTO dto in statusDTOMock)
            {
                statusCRUD.Add(dto);
            }

            StageCRUD stageCRUD = new StageCRUD();
            StageDTOMock stageDTOMock = new StageDTOMock();
            foreach (StageDTO dto in stageDTOMock)
            {
                stageCRUD.Add(dto);
            }

            InterviewStatusCRUD interviewStatusCRUD = new InterviewStatusCRUD();
            InterviewStatusDTOMock interviewStatusDTOMock = new InterviewStatusDTOMock();
            foreach (InterviewStatusDTO dto in interviewStatusDTOMock)
            {
                interviewStatusCRUD.Add(dto);
            }

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                _mockCandidateID.Add(candidateCRUD.Add(dto));
            }

            CourseCRUD courseCRUD = new CourseCRUD();
            CourseDTOMock courseDTOMock = new CourseDTOMock();
            int count = 0;
            foreach (CourseDTO dto in courseDTOMock)
            {
                _mockCourseID.Add(courseCRUD.Add(dto));
                _mockCourseID.Add(courseCRUD.Add(dto));
                count++;
            }

            Course_CandidateCRUD userInterviewCRUD = new Course_CandidateCRUD();
            for (int i = 0; i < _mockCourseID.Count; i++)
            {
                Course_CandidateDTO candidateOfCourse = new Course_CandidateDTO(1, _mockCandidateID[i], _mockCourseID[i]);
                Course_CandidateDTO candidateOfCourse2 = new Course_CandidateDTO(2, _mockCourseID[_mockCourseID.Count - i - 1], _mockCourseID[i]);
                userInterviewCRUD.Add(candidateOfCourse);
                userInterviewCRUD.Add(candidateOfCourse2);
            }


        }

        [Test, TestCaseSource(typeof(AllInterviewsByDateIntervalAndUserQueryDataSource))]
        public void SelectAllInterviewsByDateIntervalTest(int idnumber, DateTime startDateTime, DateTime finishDateTime, List<AllInterviewsDTO> expected)
        {
            AllInterviewsByDateIntervalAndUserQuery _allInterviewsQuery = new AllInterviewsByDateIntervalAndUserQuery();
            List<AllInterviewsDTO> actual = _allInterviewsQuery.SelectAllInterviewsByDateIntervalAndUser(startDateTime, finishDateTime, _mockCourseID[idnumber]);

            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {
            //Удаление добавленных элементов

        }

        public class AllInterviewsByDateIntervalAndUserQueryDataSource : IEnumerable
        {
            List<AllInterviewsDTO> firstTest = new List<AllInterviewsDTO>();

            AllInterviewsDTO interviewSergey1 = new AllInterviewsDTO()
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

            AllInterviewsDTO interviewSergey2 = new AllInterviewsDTO()
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

            List<AllInterviewsDTO> secondTest = new List<AllInterviewsDTO>();

            AllInterviewsDTO interviewPolina1 = new AllInterviewsDTO()
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

            AllInterviewsDTO interviewPolina2 = new AllInterviewsDTO()
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

            List<AllInterviewsDTO> thirdTest = new List<AllInterviewsDTO>();

            AllInterviewsDTO interviewSvetlana1 = new AllInterviewsDTO()
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

            AllInterviewsDTO interviewSvetlana2 = new AllInterviewsDTO()
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


            public IEnumerator GetEnumerator()
            {
                firstTest.Add(interviewSergey1);
                firstTest.Add(interviewSergey2);
                secondTest.Add(interviewPolina1);
                secondTest.Add(interviewPolina2);
                thirdTest.Add(interviewSvetlana1);
                thirdTest.Add(interviewSvetlana2);

                yield return new object[] { 0, new DateTime(2019, 7, 20, 18, 30, 00), new DateTime(2021, 9, 20, 12, 00, 00), firstTest };
                yield return new object[] { 1, new DateTime(2019, 8, 20, 10, 30, 00), new DateTime(2021, 8, 20, 10, 30, 00), secondTest };
                yield return new object[] { 2, new DateTime(2019, 8, 20, 10, 30, 00), new DateTime(2021, 9, 12, 15, 00, 00), thirdTest };
            }
        }
    }
}
        
