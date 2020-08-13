using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
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
        SqlConnection Connection;

        [SetUp]
        public void Setup()
        {
            Connection = ConnectionSingleTone.GetInstance().Connection;
            _mockUserID = new List<int>();
            _mockTaskID = new List<int>();
            _mockCandidateID = new List<int>();

        }
    }
}
