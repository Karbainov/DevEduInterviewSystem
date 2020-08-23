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
        AllTablesMock AllTablesMock = new AllTablesMock();

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;            
            AllTablesMock.AddData();
        } 

        [Test, TestCaseSource(typeof(AllInterviewsByUserQueryDataSource))]
        public void SelectAllByUserTest(int idnumber, List<AllInterviewsDTO> expected)
        {
            AllInterviewsByUserQuery _allInterviewsQuery = new AllInterviewsByUserQuery();
            List<AllInterviewsDTO> actual = _allInterviewsQuery.SelectAllInterviewsByUser(AllTablesMock.UserID[idnumber]);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {
            AllTablesMock.DeleteData();
        }

        public class AllInterviewsByUserQueryDataSource : IEnumerable
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
                CandidateFirstName = "Vasya",
                CandidateLastName = "Pupkin",
                CandidatePhone = "911",
                DateTimeInterview = new DateTime(2020, 09, 12, 15, 00, 00),
                Attempt = 1,
                InterviewStatus = "success"
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

                yield return new object[] { 0, firstTest };
                yield return new object[] { 1, secondTest };
                yield return new object[] { 2, thirdTest };
            }

            
        }
    }
}