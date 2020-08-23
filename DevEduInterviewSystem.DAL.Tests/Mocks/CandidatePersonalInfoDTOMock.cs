using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class CandidatePersonalInfoDTOMock : IEnumerable 
	{
        public IEnumerator GetEnumerator()
        {
			yield return new CandidatePersonalInfoDTO(1, 1, true, "school", "freelance", "cats", "social", "Pupkin", "job");
			yield return new CandidatePersonalInfoDTO(2, 2, false, "univer", "office", "no", "dogs", "email", "job");
			yield return new CandidatePersonalInfoDTO(3, 3, true, "school", "home", "1 year", "reading", "promo", "no");
			yield return new CandidatePersonalInfoDTO(4, 1, false, "univer", "office", "no", "TV", "email", "job");
		}
    }
}
