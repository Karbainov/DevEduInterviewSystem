using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO.CandidateSelectionProcessInfoDTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
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
        //private List<int> _mockCourseID;

        //private List<DateTime> _mockDate;

        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            _mockCandidateID = new List<int>();  

            CourseCRUD courseCRUD = new CourseCRUD();
            CourseDTOMock courseDTOMock = new CourseDTOMock();
            foreach (CourseDTO dto in courseDTOMock)
            {
                courseCRUD.Add(dto);
            }


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

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                _mockCandidateID.Add(candidateCRUD.Add(dto));
            }
        }

        [Test, TestCaseSource(typeof(CandidateSelectionProcessInfoByIDDataSource))]
        
        public void SelectCandidateInfoByID(int idNumber, List<AllSelectionProcessDTO> expected)
        {
            SelectionProcessByIDQuery _selectionProcessByIDQuery = new SelectionProcessByIDQuery();
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
                FirstName = "Sergey",
                LastName = "Timofeev",
                Status = "Точно подходит",
                Stage = "Waiting interview",
                Course = "BaseC#"
            };

            List<AllSelectionProcessDTO> secondTest = new List<AllSelectionProcessDTO>();

            AllSelectionProcessDTO selectionProcessPolina = new AllSelectionProcessDTO()
            {
                FirstName = "Polina",
                LastName = "Matveevna",
                Status = "Скорее подходит",
                Stage = "Doing homework",
                Course = "Mobile"
            };
            public IEnumerator GetEnumerator()
            {
                firstTest.Add(selectionProcessVasya1);
                secondTest.Add(selectionProcessPolina);
                yield return new object[] { 0, firstTest };
                yield return new object[] { 1, secondTest };
            }
        }
    }
}


           

