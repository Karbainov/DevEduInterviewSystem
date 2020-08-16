using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
   public class GroupDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new GroupDTO(1,1,"BackEnd", new DateTime(2020, 8, 20, 18, 30, 00), new DateTime(2020, 12, 20, 18, 30, 00));
            yield return new GroupDTO(2, 2, "FrontEnd", new DateTime(2020, 4, 20, 18, 30, 00), new DateTime(2020, 7, 20, 18, 30, 00));
            yield return new GroupDTO(3, 3, "BaseC#", new DateTime(2020, 3, 20, 18, 30, 00), new DateTime(2020, 6, 20, 18, 30, 00));
            yield return new GroupDTO(4, 4, "Mobile", new DateTime(2020, 2, 20, 18, 30, 00), new DateTime(2020, 4, 20, 18, 30, 00));
        }
    }
}
