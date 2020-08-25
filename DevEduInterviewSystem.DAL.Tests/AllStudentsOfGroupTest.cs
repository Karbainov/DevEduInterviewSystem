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
        AllTablesMock AllTablesMock = new AllTablesMock();

        [SetUp]
        public void Setup()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            AllTablesMock.AddData();
        }

        [Test, TestCaseSource(typeof(AllStudentsOfGroupProcedureDataSourse))]
        public void SelectAllStudentsOfGroupTest(int idnumber, List<AllStudentsOfGroupDTO> expected)
        {
            AllStudentsOfGroup _allstudents = new AllStudentsOfGroup();
            List<AllStudentsOfGroupDTO> actual = _allstudents.SelectAllStudentsOfGroup(AllTablesMock.GroupID[idnumber]);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {
            AllTablesMock.DeleteData();
        }
    }

    public class AllStudentsOfGroupProcedureDataSourse : IEnumerable
    {

        List<AllStudentsOfGroupDTO> firstTest = new List<AllStudentsOfGroupDTO>();

        AllStudentsOfGroupDTO groupTest1 = new AllStudentsOfGroupDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Ivan",
            StudentLastName = "Sidorov"
        };

        AllStudentsOfGroupDTO groupTest2 = new AllStudentsOfGroupDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Yana",
            StudentLastName = "Smirnova"
        };
        AllStudentsOfGroupDTO groupTest3 = new AllStudentsOfGroupDTO()
        {
            Name = "FrontEnd",
            StudentFirstName = "Yana",
            StudentLastName = "Smirnova"
        };

        List<AllStudentsOfGroupDTO> secondTest = new List<AllStudentsOfGroupDTO>();

        AllStudentsOfGroupDTO groupTest5 = new AllStudentsOfGroupDTO()
        {
            Name = "BaseC#",
            StudentFirstName = "Yana",
            StudentLastName = "Smirnova"
        };

        AllStudentsOfGroupDTO groupTest6 = new AllStudentsOfGroupDTO()
        {
            Name = "BaseC#",
            StudentFirstName = "Ivan",
            StudentLastName = "Sidorov"
        };
        AllStudentsOfGroupDTO groupTest7 = new AllStudentsOfGroupDTO()
        {
            Name = "BaseC#",
            StudentFirstName = "Yana",
            StudentLastName = "Smirnova"
        };

        List<AllStudentsOfGroupDTO> thirdTest = new List<AllStudentsOfGroupDTO>();

        AllStudentsOfGroupDTO groupTest9 = new AllStudentsOfGroupDTO()
        {
            Name = "Mobile",
            StudentFirstName = "Elena",
            StudentLastName = "Kac"
        };

        AllStudentsOfGroupDTO groupTest10 = new AllStudentsOfGroupDTO()
        {
            Name = "Mobile",
            StudentFirstName = "Vasya",
            StudentLastName = "Pupkin"
        };
        AllStudentsOfGroupDTO groupTest11 = new AllStudentsOfGroupDTO()
        {
            Name = "Mobile",
            StudentFirstName = "Yana",
            StudentLastName = "Smirnova"
        };

        public IEnumerator GetEnumerator()
        {
            firstTest.Add(groupTest1);
            firstTest.Add(groupTest2);
            firstTest.Add(groupTest3);
            secondTest.Add(groupTest5);
            secondTest.Add(groupTest6);
            secondTest.Add(groupTest7);
            thirdTest.Add(groupTest9);
            thirdTest.Add(groupTest10);
            thirdTest.Add(groupTest11);

            yield return new object[] { 1, firstTest };
            yield return new object[] { 2, secondTest };
            yield return new object[] { 3, thirdTest };
        }
    };
};
