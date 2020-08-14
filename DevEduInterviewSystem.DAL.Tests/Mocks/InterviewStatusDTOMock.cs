using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace DevEduInterviewSystem.DAL.Tests
{
    public class InterviewStatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new InterviewStatusDTO(1, "success");
            yield return new InterviewStatusDTO(2, "fail");
            yield return new InterviewStatusDTO(3, "canceled");
        }
    }
}
