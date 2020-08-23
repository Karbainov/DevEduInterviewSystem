using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class TestStatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestStatusDTO(1, "100 баллов");
            yield return new TestStatusDTO(2, "50 баллов");
            yield return new TestStatusDTO(3, "Тест не пройден");
        }

    }
}
