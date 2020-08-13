using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class TaskDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TaskDTO(1, 2, 1, "Check HW", "1");
            yield return new TaskDTO(2, 1, 2, "Check Test", "1");
            yield return new TaskDTO(3, 4, 3, "Send Feedback", "1");
            yield return new TaskDTO(4, 3, 4, "Call back", "1");
        }
    }
}
