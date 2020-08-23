using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO.StudentsOfGroup;
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
    public class AllStudentsOfGroupTest
    {
        private List<int> _mockGroupID;
        private List<int> _mockGroupCandidateID;
        private List<int> _mockCandidateID;

        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.MainConnectionString;
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            _mockGroupID = new List<int>();
            _mockCandidateID = new List<int>();
            _mockGroupCandidateID = new List<int>();

            CourseCRUD courseCRUD = new CourseCRUD();
            CourseDTOMock courseDTOMock = new CourseDTOMock();
            foreach (CourseDTO dto in courseDTOMock)
            {
                courseCRUD.Add(dto);
            }

            GroupCRUD groupCRUD = new GroupCRUD();
            GroupDTOMock groupDTOMock = new GroupDTOMock();

            foreach (GroupDTO dto in groupDTOMock)
            {
                _mockGroupID.Add(groupCRUD.Add(dto));
            }

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                _mockCandidateID.Add(candidateCRUD.Add(dto));
            }

            GroupCandidateCRUD groupCandidateCRUD = new GroupCandidateCRUD();
            for (int i = 0; i < _mockGroupID.Count; i++)
            {
                GroupCandidateDTO groupCandidate1 = new GroupCandidateDTO(1, _mockGroupID[i], _mockCandidateID[i]);
                GroupCandidateDTO groupCandidate2 = new GroupCandidateDTO(2, _mockGroupID[_mockGroupID.Count - i - 1], _mockCandidateID[i]);
                GroupCandidateDTO groupCandidate3 = new GroupCandidateDTO(3, _mockGroupID[_mockGroupID.Count - i - 1], _mockCandidateID[i]);
                GroupCandidateDTO groupCandidate4 = new GroupCandidateDTO(4, _mockGroupID[_mockGroupID.Count - i - 1], _mockCandidateID[i]);
                groupCandidateCRUD.Add(groupCandidate1);
                groupCandidateCRUD.Add(groupCandidate2);
                groupCandidateCRUD.Add(groupCandidate3);
                groupCandidateCRUD.Add(groupCandidate4);
            }
        }

        [Test, TestCaseSource(typeof(AllStudentsOfGroupProcedureDataSourse))]
        public void SelectAllStudentsOfGroupTest(int idnumber, List<AllStudentsOfGroupDTO> expected)
        {
            AllStudentsOfGroupProcedure _allstudents = new AllStudentsOfGroupProcedure();
            List<AllStudentsOfGroupDTO> actual = _allstudents.SelectAllStudentsOfGroup(_mockGroupID[idnumber]);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {


        }
    }

    public class AllStudentsOfGroupProcedureDataSourse : IEnumerable
    {

        List<AllStudentsOfGroupDTO> firstTest = new List<AllStudentsOfGroupDTO>();

        AllStudentsOfGroupDTO groupTest1 = new AllStudentsOfGroupDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Vasya",
            StudentLastName = "Petrov"
        };

        AllStudentsOfGroupDTO groupTest2 = new AllStudentsOfGroupDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Aleksey",
            StudentLastName = "Pupkin"
        };
        AllStudentsOfGroupDTO groupTest3 = new AllStudentsOfGroupDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Tyga",
            StudentLastName = "Brendovich"
        };
        AllStudentsOfGroupDTO groupTest4 = new AllStudentsOfGroupDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Anatoliy",
            StudentLastName = "Kashpirovskiy"
        };

        List<AllStudentsOfGroupDTO> secondTest = new List<AllStudentsOfGroupDTO>();

        AllStudentsOfGroupDTO groupTest5 = new AllStudentsOfGroupDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Vasya",
            StudentLastName = "Petrov"
        };

        AllStudentsOfGroupDTO groupTest6 = new AllStudentsOfGroupDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Aleksey",
            StudentLastName = "Pupkin"
        };
        AllStudentsOfGroupDTO groupTest7 = new AllStudentsOfGroupDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Tyga",
            StudentLastName = "Brendovich"
        };
        AllStudentsOfGroupDTO groupTest8 = new AllStudentsOfGroupDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Anatoliy",
            StudentLastName = "Kashpirovskiy"
        };

        List<AllStudentsOfGroupDTO> thirdTest = new List<AllStudentsOfGroupDTO>();

        AllStudentsOfGroupDTO groupTest9 = new AllStudentsOfGroupDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Vasya",
            StudentLastName = "Petrov"
        };

        AllStudentsOfGroupDTO groupTest10 = new AllStudentsOfGroupDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Aleksey",
            StudentLastName = "Pupkin"
        };
        AllStudentsOfGroupDTO groupTest11 = new AllStudentsOfGroupDTO()
        {
            Name = "backEnd",
            StudentFirstName = "Tyga",
            StudentLastName = "Brendovich"
        };
        AllStudentsOfGroupDTO groupTest12 = new AllStudentsOfGroupDTO()
        {
            Name = "baseC#",
            StudentFirstName = "Anatoliy",
            StudentLastName = "Kashpirovskiy"
        };


        public IEnumerator GetEnumerator()
        {
            firstTest.Add(groupTest1);
            firstTest.Add(groupTest2);
            firstTest.Add(groupTest3);
            firstTest.Add(groupTest4);
            secondTest.Add(groupTest5);
            secondTest.Add(groupTest6);
            secondTest.Add(groupTest7);
            secondTest.Add(groupTest8);
            thirdTest.Add(groupTest9);
            thirdTest.Add(groupTest10);
            thirdTest.Add(groupTest11);
            thirdTest.Add(groupTest12);

            yield return new object[] { 1, firstTest };
            yield return new object[] { 2, secondTest };
            yield return new object[] { 3, thirdTest };
        }
    };
}