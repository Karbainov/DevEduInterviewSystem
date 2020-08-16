using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class CourseDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new CourseDTO(1, "BaseC#");
            yield return new CourseDTO(2, "Frontend");
            yield return new CourseDTO(3, "BackEnd");
            yield return new CourseDTO(4, "Mobile");

        }
    }
}
