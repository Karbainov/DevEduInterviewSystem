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
            yield return new InterviewDTO(1, 30, 1, 1, new DateTime(2020, 7, 20, 18, 30, 00));
            yield return new InterviewDTO(1, 31, 2, 2, new DateTime(2020, 8, 20, 10, 30, 00));
            yield return new InterviewDTO(1, 32, 3, 1, new DateTime(2020, 9, 20, 12, 00, 00));
            yield return new InterviewDTO(1, 33, 2, 1, new DateTime(2020, 9, 12, 15, 00, 00));
        }
    }
}
