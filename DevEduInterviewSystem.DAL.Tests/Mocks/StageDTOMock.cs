using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class StageDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new StageDTO(1, "Waiting interview");
            yield return new StageDTO(2, "Failed interview");
            yield return new StageDTO(3, "Doing homework");
        }
    }
}
