using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    [TestFixture]
    public class CandidateCRUDTest
    {
		SqlConnection Connection;
		private CandidateCRUD _candidateCRUD;
		private List<int> _mockID = new List<int>();

		[SetUp]

		public void SetUp()
		{
			Connection = ConnectionSingleTone.GetInstance().Connection;
			//Заполнение таблицы до начала тестов
			_candidateCRUD = new CandidateCRUD();
			CandidateDTOMock mock = new CandidateDTOMock();

			_mockID = new List<int>();

			foreach (CandidateDTO candidate in mock)
			{
				_mockID.Add(_candidateCRUD.Add(candidate));
				Connection.Close();
			}
		}

		[Test, TestCaseSource(typeof(Test1DataSource))]

		public void Test1(int idnumber, CandidateDTO expected)
		{
			CandidateDTO actual = _candidateCRUD.SelectByID(idnumber);
			expected.ID = idnumber;
			Assert.AreEqual(expected, actual);
		}

		[TearDown]
		public void TearDown()
		{
			foreach (int id in _mockID)
			{
				_candidateCRUD.DeleteByID(id);
				Connection.Close();
			}

		}

		public class Test1DataSource : IEnumerable
		{
			CandidateDTO candidate1 = new CandidateDTO(30, 1, 1, 1, "911", "v@ya.ru", "Vasya", "Pupkin", new DateTime(2020, 08, 12, 21, 30, 48));

            public IEnumerator GetEnumerator()
            {
				yield return new object[] { 30, candidate1 };
				yield return new object[] { 1, new CandidateDTO() { FirstName = "fvb" } };
				yield return new object[] { 2, new CandidateDTO() { FirstName = "sdvg" } };
			}
        }

	}
	
}
