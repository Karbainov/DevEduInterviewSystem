using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class AllDTOMocks : IEnumerable
	{
		public IEnumerator GetEnumerator()
		{
            //Важно вызывать в правильно порядке, чтобы первыми заполнялись таблицы, на которые ссылается ForeignKey в других таблицах
            //yield return new UserDTOMock();
            //yield return new CityDTOMock();
            //yield return new StatusDTOMock();
            //yield return new StageDTOMock();
            //yield return new InterviewStatusDTOMock();
            //yield return new CandidateDTOMock();
            //yield return new InterviewDTOMock();
            //yield return new UserInterviewDTOMock();

            yield return new object[] { new UserDTOMock() };
            yield return new object[] { new CityDTOMock() };
            yield return new object[] { new StatusDTOMock() };
            yield return new object[] { new StageDTOMock() };
            yield return new object[] { new InterviewStatusDTOMock() };
            yield return new object[] { new CandidateDTOMock() };
            yield return new object[] { new InterviewDTOMock() };
            yield return new object[] { new UserInterviewDTOMock() };
        }
	}
}
