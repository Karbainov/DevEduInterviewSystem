using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class HomeWorkStatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new HomeworkStatusDTO(1, "Done");
            yield return new HomeworkStatusDTO(2, "Not done");
        }
    }
}
