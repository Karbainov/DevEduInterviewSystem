using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class CandidateDTOMock : IEnumerable 
	{
        public IEnumerator GetEnumerator()
        {
			yield return new CandidateDTO(1, 1, 1, 1, "+911", "v@ya.ru", "Vasya", "Pupkin", DateTime.Now);
			yield return new CandidateDTO(2, 2, 2, 2, "+821", "i@ya.ru", "Ivan", "Sidorov", DateTime.Now);
			yield return new CandidateDTO(3, 3, 3, 3, "+8921", "y@ya.ru", "Yana", "Smirnova", DateTime.Now);
		}
    }
}
