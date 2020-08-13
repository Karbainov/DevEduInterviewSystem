using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace DevEduInterviewSystem.DAL.Tests
{
    public class InterviewDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new InterviewDTO(1, 30, 1, 1, DateTime.Now);
            yield return new InterviewDTO(1, 31, 2, 2, DateTime.Now);
            yield return new InterviewDTO(1, 32, 3, 1, DateTime.Now);
        }
    }
}
