using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class HomeworkStatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new HomeworkStatusDTO(1, "Сдана");
            yield return new HomeworkStatusDTO(2, "Пропущен срок сдачи");
            yield return new HomeworkStatusDTO(3, "Отправлена кандидату");
        }

    }
}
