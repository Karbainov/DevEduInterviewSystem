using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
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
    public class AllTasksByUserTest
    {
        private List<int> _mockUserID;
        private List<int> _mockTaskID;
        private List<int> _mockCandidateID;
        //SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
           
            //Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            _mockUserID = new List<int>();
            _mockTaskID = new List<int>();


            _mockCandidateID = new List<int>();

            UserCRUD userCRUD = new UserCRUD();
            UserDTOMock userDTOMock = new UserDTOMock();
            foreach (UserDTO dto in userDTOMock)
            {
                _mockUserID.Add(userCRUD.Add(dto));
            }

            CityCRUD cityCRUD = new CityCRUD();
            CityDTOMock cityDTOMock = new CityDTOMock();
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

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                _mockCandidateID.Add(candidateCRUD.Add(dto));
            }

            TaskCRUD taskCRUD = new TaskCRUD();
            for (int i = 0; i < _mockUserID.Count; i++)
            {
                TaskDTO task1 = new TaskDTO(1, _mockTaskID[i], _mockUserID[i]);
                TaskDTO task2 = new TaskDTO(2, _mockTaskID[_mockUserID.Count - i - 1], _mockUserID[i]);
                taskCRUD.Add(task1);
                taskCRUD.Add(task2);
            }
        }

        [Test, TestCaseSource(typeof(AllTasksByUserQueryDataSource))]
        public void SelectAllByUserTest(int idnumber, List<AllInterviewsDTO> expected)
        {
            AllTasksByUserQuery _allTasks = new AllTasksByUserQuery();
            List<AllTasksByUserDTO> actual = _allTasks.SelectAllTasksByUser(_mockUserID[idnumber]);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {

        }

        public class AllTasksByUserQueryDataSource : IEnumerable
        {

            List<AllTasksByUserDTO> firstTest = new List<AllTasksByUserDTO>();

            AllTasksByUserDTO taskSergey1 = new AllTasksByUserDTO()
            {
                UserFirstName = "Sergey",
                UserLastName = "Timofeev",
                CandidateFirstName = "Vasya",
                CandidateLastName = "Pupkin",
                Task = "Call back",
                IsCompleted = false,
                Stage = "Newbee"
            };

            AllTasksByUserDTO taskSergey2 = new AllTasksByUserDTO()
            {
                UserFirstName = "Sergey",
                UserLastName = "Timofeev",
                CandidateFirstName = "Elena",
                CandidateLastName = "Kac",
                Task = "Plan interview",
                IsCompleted = false,
                Stage = "Interview schdeuled"
            };

            List<AllTasksByUserDTO> secondTest = new List<AllTasksByUserDTO>();

            AllTasksByUserDTO taskPolina1 = new AllTasksByUserDTO()
            {
                UserFirstName = "Polina",
                UserLastName = "Matveevna",
                CandidateFirstName = "Ivan",
                CandidateLastName = "Sidorov",
                Task = "Confirm interview date",
                IsCompleted = false,
                Stage = "Newbee"
            };

            AllTasksByUserDTO taskPolina2 = new AllTasksByUserDTO()
            {
                UserFirstName = "Polina",
                UserLastName = "Matveevna",
                CandidateFirstName = "Yana",
                CandidateLastName = "Smirnova",
                Task = "Check test",
                IsCompleted = false,
                Stage = "Test scheduled"
            };

            List<AllTasksByUserDTO> thirdTest = new List<AllTasksByUserDTO>();

            AllTasksByUserDTO taskSvetlana1 = new AllTasksByUserDTO()
            {
                UserFirstName = "Svetlana",
                UserLastName = "Fokina",
                CandidateFirstName = "Ivan",
                CandidateLastName = "Svetlakov",
                Task = "Call for payment",
                IsCompleted = false,
                Stage = "Studying"
            };

            AllTasksByUserDTO taskSvetlana2 = new AllTasksByUserDTO()
            {
                UserFirstName = "Svetlana",
                UserLastName = "Fokina",
                CandidateFirstName = "Anna",
                CandidateLastName = "Fedosova",
                Task = "Call about group launching",
                IsCompleted = false,
                Stage = "Ready to start"
            };


            public IEnumerator GetEnumerator()
            {
                firstTest.Add(taskSergey1);
                firstTest.Add(taskSergey2);
                secondTest.Add(taskPolina1);
                secondTest.Add(taskPolina2);
                thirdTest.Add(taskSvetlana1);
                thirdTest.Add(taskSvetlana2);

                yield return new object[] { 0, firstTest };
                yield return new object[] { 1, secondTest };
                yield return new object[] { 2, thirdTest };
            }
        };

    }
}
