using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework;
using DevEduInterviewSystem.DAL.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    [TestFixture]
    public class AllOverdueHomeworkTest
    {
        private List<int> _mockCandidateID;
        private List<int> _mockHomeWorkID;
        private List<int> _mockHomeWorkStatusID;
        private List<int> _mockTestStatusID;
        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            _mockCandidateID = new List<int>();
            _mockHomeWorkStatusID = new List<int>();
            _mockTestStatusID = new List<int>();

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

            HomeworkStatusCRUD homeworkStatusCRUD = new HomeworkStatusCRUD();
            HomeWorkStatusDTOMock homeWorkStatusDTOMock = new HomeWorkStatusDTOMock();
            foreach (HomeworkStatusDTO dto in homeWorkStatusDTOMock)
            {
                _mockHomeWorkStatusID.Add(homeworkStatusCRUD.Add(dto));
            }

            TestStatusCRUD testkStatusCRUD = new TestStatusCRUD();
            TestStatusDTOMock testStatusDTOMock = new TestStatusDTOMock();
            foreach (TestStatusDTO dto in testStatusDTOMock)
            {
                _mockTestStatusID.Add(testkStatusCRUD.Add(dto));
            }

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                _mockCandidateID.Add(candidateCRUD.Add(dto));
            }

            HomeworkCRUD homeworkCRUD = new HomeworkCRUD();
            HomeWorkDTOMock homeWorkDTOMock = new HomeWorkDTOMock();
            foreach (HomeworkDTO dto in homeWorkDTOMock)
            {
                homeworkCRUD.Add(dto);
            }




        }

        [Test, TestCaseSource(typeof(AllOverdueHomeworksAndTestsDataSource))]
        public void GetAllOverdueHomeworksAndTestsTest(int idnumber, List<AllOverdueHomeworkDTO> expected)
        {
            GetAllOverdueHomework _allOverdueHomework = new GetAllOverdueHomework();
            List<AllOverdueHomeworkDTO> actual = _allOverdueHomework.AllOverdueHomework();
            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {
            //Удаление добавленных элементов

        }
        public class AllOverdueHomeworksAndTestsDataSource : IEnumerable
        {
            List<AllOverdueHomeworkDTO> firstTest = new List<AllOverdueHomeworkDTO>();

            AllOverdueHomeworkDTO result = new AllOverdueHomeworkDTO()
            {
                CandidateID = 1,
                CandidateFirstName = "Vasya",
                CandidateLastName = "Pupkin",
                HomeWorkDate = new DateTime(2020, 07, 20, 18, 30, 00),
                HomeWorkStatus = "Done",
                TestStatus = "Not Done"
            };

            public IEnumerator GetEnumerator()
            {
                firstTest.Add(result);
                yield return new object[] { 0, firstTest };
            }
        }

    }
}
