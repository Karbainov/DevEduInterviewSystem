using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
   public class GroupCandidateDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new GroupCandidateDTO(1,1,1);
            yield return new GroupCandidateDTO(2,2,2);
            yield return new GroupCandidateDTO(3,3,3);
            yield return new GroupCandidateDTO(4,4,4);
        }
    }
}
