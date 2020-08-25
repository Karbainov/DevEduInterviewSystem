using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO.StudentsOfCourse;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
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
    public class AllStudentsOfCourseTest
    {
        private List<int> _mockCourseID;
        private List<int> _mockCourseCandidateID;
        private List<int> _mockCandidateID;

        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            _mockCourseID = new List<int>();
            _mockCandidateID = new List<int>();
            _mockCourseCandidateID = new List<int>();

            
            CourseCRUD courseCRUD = new CourseCRUD();
            CourseDTOMock courseDTOMock = new CourseDTOMock();
            foreach (CourseDTO dto in courseDTOMock)
            {
                courseCRUD.Add(dto);
            }
                      

            foreach (CourseDTO dto in courseDTOMock)
            {
                _mockCourseID.Add(courseCRUD.Add(dto));
            }

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                _mockCandidateID.Add(candidateCRUD.Add(dto));
            }

            Course_CandidateCRUD courseCandidateCRUD = new Course_CandidateCRUD();
            for (int i = 0; i < _mockCourseID.Count; i++)
            {
                Course_CandidateDTO courseCandidate1 = new Course_CandidateDTO(1, _mockCourseID[i], _mockCandidateID[i]);
                Course_CandidateDTO courseCandidate2 = new Course_CandidateDTO(2, _mockCourseID[_mockCourseID.Count - i - 1], _mockCandidateID[i]);
                Course_CandidateDTO courseCandidate3 = new Course_CandidateDTO(3, _mockCourseID[_mockCourseID.Count - i - 1], _mockCandidateID[i]);
                Course_CandidateDTO courseCandidate4 = new Course_CandidateDTO(4, _mockCourseID[_mockCourseID.Count - i - 1], _mockCandidateID[i]);
                courseCandidateCRUD.Add(courseCandidate1);
                courseCandidateCRUD.Add(courseCandidate2);
                courseCandidateCRUD.Add(courseCandidate3);
                courseCandidateCRUD.Add(courseCandidate4);
            }
        }

        [Test, TestCaseSource(typeof(AllStudentsOfCourseProcedureDataSource))]
        public void SelectAllStudentsOfCourseTest(int idnumber, List<AllStudentsOfCourseDTO> expected)
        {
            AllStudentsOfCourse _allstudents = new AllStudentsOfCourse();
            List<AllStudentsOfCourseDTO> actual = _allstudents.SelectAllStudentsOfCourse(_mockCourseID[idnumber]);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {


        }
    }

    public class AllStudentsOfCourseProcedureDataSource : IEnumerable
    {

        List<AllStudentsOfCourseDTO> firstTest = new List<AllStudentsOfCourseDTO>();

        AllStudentsOfCourseDTO courseTest1 = new AllStudentsOfCourseDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Van",
            StudentLastName = "Darkholme"
        };

        AllStudentsOfCourseDTO courseTest2 = new AllStudentsOfCourseDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Billy",
            StudentLastName = "Herrington"
        };
        AllStudentsOfCourseDTO courseTest3 = new AllStudentsOfCourseDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Mark",
            StudentLastName = "Wolf"
        };
        AllStudentsOfCourseDTO courseTest4 = new AllStudentsOfCourseDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Ricardo",
            StudentLastName = "Milos"
        };

        List<AllStudentsOfCourseDTO> secondTest = new List<AllStudentsOfCourseDTO>();

        AllStudentsOfCourseDTO courseTest5 = new AllStudentsOfCourseDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Van",
            StudentLastName = "Darkholme"
        };

        AllStudentsOfCourseDTO courseTest6 = new AllStudentsOfCourseDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Billy",
            StudentLastName = "Herrington"
        };
        AllStudentsOfCourseDTO courseTest7 = new AllStudentsOfCourseDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Mark",
            StudentLastName = "Wolf"
        };
        AllStudentsOfCourseDTO courseTest8 = new AllStudentsOfCourseDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Ricardo",
            StudentLastName = "Milos"
        };

        List<AllStudentsOfCourseDTO> thirdTest = new List<AllStudentsOfCourseDTO>();

        AllStudentsOfCourseDTO courseTest9 = new AllStudentsOfCourseDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Van",
            StudentLastName = "Darkholme"
        };

        AllStudentsOfCourseDTO courseTest10 = new AllStudentsOfCourseDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Billy",
            StudentLastName = "Herrington"
        };
        AllStudentsOfCourseDTO courseTest11 = new AllStudentsOfCourseDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Mark",
            StudentLastName = "Wolf"
        };
        AllStudentsOfCourseDTO courseTest12 = new AllStudentsOfCourseDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Ricardo",
            StudentLastName = "Milos"
        };


        public IEnumerator GetEnumerator()
        {
            firstTest.Add(courseTest1);
            firstTest.Add(courseTest2);
            firstTest.Add(courseTest3);
            firstTest.Add(courseTest4);
            secondTest.Add(courseTest5);
            secondTest.Add(courseTest6);
            secondTest.Add(courseTest7);
            secondTest.Add(courseTest8);
            thirdTest.Add(courseTest9);
            thirdTest.Add(courseTest10);
            thirdTest.Add(courseTest11);
            thirdTest.Add(courseTest12);

            yield return new object[] { 1, firstTest };
            yield return new object[] { 2, secondTest };
            yield return new object[] { 3, thirdTest };
        }
    };
}