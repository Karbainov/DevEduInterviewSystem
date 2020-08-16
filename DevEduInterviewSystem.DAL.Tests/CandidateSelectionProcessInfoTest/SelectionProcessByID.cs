using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO.CandidateSelectionProcessInfoDTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CandidateSelectionProcessInfo;
using DevEduInterviewSystem.DAL.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.Tests.CandidateSelectionProcessInfoTest
{

    [TestFixture]
    public class SelectionProcessByIDTest
    {
        private List<int> _mockCandidateID;
        private List<int> _mockCourseID;

        //private List<DateTime> _mockDate;

        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            _mockCandidateID = new List<int>();
            _mockCourseID = new List<int>();

            CourseCRUD courseCRUD = new CourseCRUD();
            CourseDTOMock courseDTOMock = new CourseDTOMock();
            foreach (CourseDTO dto in courseDTOMock)
            {
                _mockCourseID.Add(courseCRUD.Add(dto));
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

            Course_CandidateCRUD courseCandidateCRUD = new Course_CandidateCRUD();
            for (int i = 0; i < _mockCandidateID.Count; i++)
            {
                Course_CandidateDTO courseCandidate = new Course_CandidateDTO(1, _mockCourseID[i], _mockCandidateID[i]);
                Course_CandidateDTO courseCandidate2 = new Course_CandidateDTO(2, _mockCourseID[_mockCourseID.Count - i - 1], _mockCandidateID[i]);
                courseCandidateCRUD.Add(courseCandidate);
                courseCandidateCRUD.Add(courseCandidate2);
            }

        }

        [Test, TestCaseSource(typeof(CandidateSelectionProcessInfoByIDDataSource))]
        
        public void SelectCandidateInfoByID(int idNumber, List<AllSelectionProcessDTO> expected)
        {
            SelectionProcessByIDQuery _selectionProcessByIDQuery = new SelectionProcessByIDQuery();



            List<AllSelectionProcessDTO> actual = _selectionProcessByIDQuery.SelectProcessByCandidate(_mockCandidateID[idNumber]);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {

        }

        public class CandidateSelectionProcessInfoByIDDataSource : IEnumerable
        {
            
            List<AllSelectionProcessDTO> firstTest = new List<AllSelectionProcessDTO>();

            AllSelectionProcessDTO selectionProcessVasya1 = new AllSelectionProcessDTO()
            {
                FirstName = "Vasya",
                LastName = "Pupkin",
                Status = "Точно подходит",
                Stage = "Waiting interview",
                Course = "BaseC#"
            };

            AllSelectionProcessDTO selectionProcessVasya2 = new AllSelectionProcessDTO()
            {
                FirstName = "Vasya",
                LastName = "Pupkin",
                Status = "Точно подходит",
                Stage = "Waiting interview",
                Course = "Mobile"
            };


            List<AllSelectionProcessDTO> secondTest = new List<AllSelectionProcessDTO>();

            AllSelectionProcessDTO selectionProcessPolina1 = new AllSelectionProcessDTO()
            {
                FirstName = "Ivan",
                LastName = "Sidorov",
                Status = "Скорее подходит",
                Stage = "Failed interview",
                Course = "Frontend"
            };

            AllSelectionProcessDTO selectionProcessPolina2 = new AllSelectionProcessDTO()
            {
                FirstName = "Ivan",
                LastName = "Sidorov",
                Status = "Скорее подходит",
                Stage = "Failed interview",
                Course = "BackEnd"
            };
            public IEnumerator GetEnumerator()
            {
                firstTest.Add(selectionProcessVasya1);
                firstTest.Add(selectionProcessVasya2);
                secondTest.Add(selectionProcessPolina1);
                secondTest.Add(selectionProcessPolina2);
                yield return new object[] { 0, firstTest };
                yield return new object[] { 1, secondTest };
            }
        }
    }
}


           

