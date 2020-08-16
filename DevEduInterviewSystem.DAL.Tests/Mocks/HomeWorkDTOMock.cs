using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class HomeWorkDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            DateTime dateTest1 = new DateTime(2020, 03, 03);
            DateTime dateTest2 = new DateTime(2020, 05, 03);
            DateTime dateTest3 = new DateTime(2020, 06, 03);
            DateTime dateTest4 = new DateTime(2020, 07, 03);
            yield return new HomeworkDTO(1, 1, 2, 2, dateTest1);
            yield return new HomeworkDTO(2, 2, 1, 2, dateTest2);
            yield return new HomeworkDTO(3, 3, 2, 1, dateTest3);
            yield return new HomeworkDTO(4, 4, 1, 1, dateTest4);
        }
    }
}
