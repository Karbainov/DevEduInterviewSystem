using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class TestStatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestStatusDTO(1, "Done");
            yield return new TestStatusDTO(2, "Not done");
        }
    }
}
