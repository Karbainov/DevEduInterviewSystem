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
			yield return new object[] { new CandidateDTO(1, 1, 1, 1, "+911", "v@ya.ru", "Vasya", "Pupkin", DateTime.Now) };
			yield return new object[] { new CandidateDTO() { FirstName = "fvb" } };
			yield return new object[] { new CandidateDTO() { FirstName = "sdvg" } };
		}
    }
}
