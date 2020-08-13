using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class AllCRUDMocks : IEnumerable
	{

		public IEnumerator GetEnumerator()
		{
            //Важно вызывать в правильно порядке, чтобы первыми заполнялись таблицы, на которые ссылается ForeignKey в других таблицах

            //yield return new UserCRUD();
            //yield return new CityCRUD();
            //yield return new StatusCRUD();
            //yield return new StageCRUD();
            //yield return new InterviewStatusCRUD();
            //yield return new CandidateCRUD();
            //yield return new InterviewCRUD();
            //yield return new UserInterviewCRUD();

            yield return new object[] { new UserCRUD() };
            yield return new object[] { new CityCRUD() };
            yield return new object[] { new StatusCRUD() };
            yield return new object[] { new StageCRUD() };
            yield return new object[] { new InterviewStatusCRUD() };
            yield return new object[] { new CandidateCRUD() };
            yield return new object[] { new InterviewCRUD() };
            yield return new object[] { new UserInterviewCRUD() };
        }
	}
}
