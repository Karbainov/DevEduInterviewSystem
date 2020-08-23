using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
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
            Course2DTOMock courseDTOMock = new Course2DTOMock();
            int count = 0;
            foreach (CourseDTO dto in courseDTOMock)
            {
                courseCRUD.Add(dto);
                count++;
            }

            Course_CandidateCRUD сourseСandidateCRUD = new Course_CandidateCRUD();
            for (int i = 0; i < _mockCourseID.Count; i++)
            {
                Course_CandidateDTO candidateOfCourse = new Course_CandidateDTO(1, _mockCandidateID[i], _mockCourseID[i]);
                Course_CandidateDTO candidateOfCourse2 = new Course_CandidateDTO(2, _mockCourseID[_mockCourseID.Count - i - 1], _mockCourseID[i]);
                сourseСandidateCRUD.Add(candidateOfCourse);
                сourseСandidateCRUD.Add(candidateOfCourse2);
            }


        }

        [Test, TestCaseSource(typeof(AllCandidateOfAllCoursesQueryDataSource))]
        public void SelectAllCandidateOfAllCoursesTest(int idnumber, List<AllCandidateOfCourseDTO> expected)
        {
            AllCandidateOfAllCoursesQuery _allCandidateOfAllCoursesQuery = new AllCandidateOfAllCoursesQuery();
            List<AllCandidateOfCourseDTO> actual = _allCandidateOfAllCoursesQuery.SelectAllCandidateOfCourse();

            Assert.AreEqual(expected, actual); 

        }

        [TearDown]
        public void TearDown()
        {
            //Удаление добавленных элементов

        }

        public class AllCandidateOfAllCoursesQueryDataSource : IEnumerable
        {
            List<AllCandidateOfCourseDTO> firstTest = new List<AllCandidateOfCourseDTO>();

            AllCandidateOfCourseDTO courseSergey1 = new AllCandidateOfCourseDTO()
            {
                Name = "FrontEnd",
                CandidateID = 1,
                CandidateFirstName = "Vasya",
                CandidateLastName = "Pupkin"

            };

            AllCandidateOfCourseDTO courseSergey2 = new AllCandidateOfCourseDTO()
            {
                Name = "Base course",
                CandidateID = 2,
                CandidateFirstName = "Elena",
                CandidateLastName = "Kac",

            };

            List<AllCandidateOfCourseDTO> secondTest = new List<AllCandidateOfCourseDTO>();

            AllCandidateOfCourseDTO coursePolina1 = new AllCandidateOfCourseDTO()
            {
                Name = "Base course",
                CandidateID = 3,
                CandidateFirstName = "Ivan",
                CandidateLastName = "Sidorov",

            };

            AllCandidateOfCourseDTO coursePolina2 = new AllCandidateOfCourseDTO()
            {
                Name = "Mobile Xamarin",
                CandidateID = 4,
                CandidateFirstName = "Yana",
                CandidateLastName = "Smirnova",

            };

            List<AllCandidateOfCourseDTO> thirdTest = new List<AllCandidateOfCourseDTO>();

            AllCandidateOfCourseDTO courseSvetlana1 = new AllCandidateOfCourseDTO()
            {
                Name = "Mobile Xamarin",
                CandidateID = 3,
                CandidateFirstName = "Ivan",
                CandidateLastName = "Sidorov",

            };

            AllCandidateOfCourseDTO courseSvetlana2 = new AllCandidateOfCourseDTO()
            {
                Name = "Base course",
                CandidateID = 4,
                CandidateFirstName = "Yana",
                CandidateLastName = "Smirnova",

            };


            public IEnumerator GetEnumerator()
            {
                firstTest.Add(courseSergey1);
                firstTest.Add(courseSergey2);
                secondTest.Add(coursePolina1);
                secondTest.Add(coursePolina2);
                thirdTest.Add(courseSvetlana1);
                thirdTest.Add(courseSvetlana2);

                yield return new object[] { 0, firstTest };
                yield return new object[] { 1, secondTest };
                yield return new object[] { 2, thirdTest };
            }
        }
    }
}
        

