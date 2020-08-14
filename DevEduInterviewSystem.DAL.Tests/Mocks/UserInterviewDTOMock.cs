using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class UserInterviewDTOMock : IEnumerable
	{
        public IEnumerator GetEnumerator()
        {
			yield return new UserInterviewDTO(1, 1, 1);
			yield return new UserInterviewDTO(2, 2, 2);
			yield return new UserInterviewDTO(3, 3, 3);
		}
    }
}
