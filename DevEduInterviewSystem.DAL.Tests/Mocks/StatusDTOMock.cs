using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class StatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new StatusDTO(1, "Точно подходит");
            yield return new StatusDTO(2, "Скорее подходит");
            yield return new StatusDTO(3, "Совсем не подходит");
        }

    }
}
