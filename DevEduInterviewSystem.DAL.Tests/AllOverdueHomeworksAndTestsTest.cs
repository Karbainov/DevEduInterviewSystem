using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    [TestFixture]
    public class AllOverdueHomeworksAndTestsTest
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
            _mockHomeWorkID = new List<int>();
            _mockHomeWorkStatusID = new List<int>();
            _mockTestStatusID = new List<int>();

            HomeworkStatusCRUD homeworkStatusCRUD = new HomeworkStatusCRUD();
            HomeWorkStatusDTOMock homeWorkStatusDTOMock = new HomeWorkStatusDTOMock();
            foreach (HomeworkStatusDTO dto in homeWorkStatusDTOMock)
            {
                homeworkStatusCRUD.Add(dto);
            }

            TestStatusCRUD testkStatusCRUD = new TestStatusCRUD();
            TestStatusDTOMock testStatusDTOMock = new TestStatusDTOMock();
            foreach (TestStatusDTO dto in testStatusDTOMock)
            {
                testkStatusCRUD.Add(dto);
            }

            HomeworkCRUD homeworkCRUD = new HomeworkCRUD();
            HomeWorkDTOMock homeWorkDTOMock = new HomeWorkDTOMock();
            foreach (HomeworkDTO dto in homeWorkDTOMock)
            {
                homeworkCRUD.Add(dto);
            }

            CandidateCRUD candidateCRUD = new CandidateCRUD();
            CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
            foreach (CandidateDTO dto in candidateDTOMock)
            {
                candidateCRUD.Add(dto);
            }


        }
    }
}
