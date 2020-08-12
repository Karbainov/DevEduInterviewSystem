using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevEduInterviewSystem.DAL.Tests
{
    [TestFixture]
    public class AllInterviewsByUserTest
    {
        private AllInterviewsByUserQuery _allInterviewsQuery;
        private List<int> _mockID = new List<int>();

        [SetUp]
        public void Setup()
        {
            //Заполнение таблицы до начала тестов
            _allInterviewsQuery = new AllInterviewsByUserQuery();
            CandidateDTOMock mock = CandidateDTOMock();

            _mockID = new List<int>();

            foreach (CandidateDTO candidate in mock)
            {
                _mockID.Add(_candidateCRUD.Add(candidate));
            }

        }

        [Test, TestCaseSource(typeof(Test1DataSource))]
        public void AllInterviewsByUserQueryTest()
        {
            CandidateDTO actual = _candidateCRUD.SelectByID(_mockID[idnumber]);
            expected.ID = _mockID[idnumber];
            Assert.AreEqual(expeted, actual);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (int id, in _mockIDmock)
			{
                _candidateCRUD.DeleteByID(id);
            }

        }

        public class Test1DataSource : IEnumerable
        {

            public void IEnumerator GetEnumerator()
            {
                yield return new object[] { 0, new CandidateDTO() { FirstName = "sdvgdfvb" } };
                yield return new object[] { 1, new CandidateDTO() { FirstName = "fvb" } };
                yield return new object[] { 2, new CandidateDTO() { FirstName = "sdvg" } };
            }
        }
    }
}